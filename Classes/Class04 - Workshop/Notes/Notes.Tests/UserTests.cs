using Microsoft.Extensions.Options;
using Notes.Common.Models;
using Notes.DataAccess;
using Notes.DataModels.Models;
using Notes.ServiceModels.UserModels;
using Notes.Services;
using System.Text;
using System.Security.Cryptography;

namespace Notes.Tests;

[TestClass]
public class UserTests
{
    private Mock<IRepository<User>> _userRepository;
    private IOptions<MyAppSettings> _options;

    public UserTests()
    {
        _userRepository = new Mock<IRepository<User>>();
        _options = Options.Create<MyAppSettings>(new MyAppSettings()
        {
            Secret = "SECRET FOR TESTING!"
        });
    }

    [TestMethod]
    public void Register_Username_Already_Exists()
    {
        // Arrange
        var users = new List<User>
        {
            new User
            {
                Id = 3,
                FirstName = "Dedo",
                LastName = "Iljo",
                Username = "dedoiljo",
                Password = "dedoiljo1"
            }
        };

        _userRepository.Setup(x => x.GetAll()).Returns(users);

        var request = new RegisterUserDto
        {
            Username = "dedoiljo",
        };

        var service = new UserService(_userRepository.Object, _options);

        // Act
        // Assert
        Assert.ThrowsException<Exception>(() =>
        {
            service.Register(request);
        });
    }

    public void Register_NotValidPassword()
    {
        // Arrange
        var users = new List<User>
        {
            new User
            {
                Id = 3,
                FirstName = "Dedo",
                LastName = "Iljo",
                Username = "dedoiljo",
                Password = "dedoiljo1"
            }
        };

        _userRepository.Setup(x => x.GetAll()).Returns(users);

        var request = new RegisterUserDto
        {
            Username = "dedoiljo1",
            Password = "asdfghjkl"
        };

        var service = new UserService(_userRepository.Object, _options);

        // Act 
        // Assert   => pravi sporedba edno so drugo, expected so result
        Assert.ThrowsException<Exception>(() =>
        {
            service.Register(request);
        });


    }

    public void Register_SuccessfullyRegisteredUser()
    {
        var password = "dedoiljo1";
        // Arrange
        var users = new List<User>
        {
            new User
            {
                Id = 3,
                FirstName = "Dedo",
                LastName = "Iljo",
                Username = "dedoiljo",
                Password = "dedoiljo1"
            }
        };

        var request = new RegisterUserDto
        {
            Username = "newUser",
            Password = "newPassword",
        };

        _userRepository.Setup(x => x.Insert(It.IsAny<User>())).Callback((User user) =>
        {
            users.Add(user);
        });

        var expectedUsers = 2;
        var expectedUser = users[1];

        // Act
        var service = new UserService(_userRepository.Object, _options);
        service.Register(request);

        // Assert

    }







    private string HashPassword(string password)
    {
        var md5 = new MD5CryptoServiceProvider();
        var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
        var hashedPassword = Encoding.ASCII.GetString(md5data);
        return hashedPassword;
    }
}
