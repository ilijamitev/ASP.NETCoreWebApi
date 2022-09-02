using Class10.WebApiDemo.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Class10.WebApiDemo.Services;

public class UserService
{
    private List<User> _users = new()
    {
        new User
        {
            Id = 1,
            FirstName = "Ilija",
            LastName = "Mitev",
            Username = "ilmit",
            Password = "ilmit123"
        },
        new User
        {
            Id = 2,
            FirstName = "Kiko",
            LastName = "Kikovski",
            Username = "kikokiko",
            Password = "kiko123"
        },
    };

    public void Register(RegisterModel request)
    {
        var user = ValidateUser(request.Username);

        if (user != null)
        {
            throw new Exception("Username already exists");
        }

        if (!ValidatePassword(request.Password))
        {
            throw new Exception("Password not valid");
        }

        var hashedPassword = HashPassword(request.Password);

        var newUser = new User
        {
            Id = _users.Count + 1,
            Username = request.Username,
            Password = hashedPassword,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        _users.Add(newUser);
    }



    public UserDto Login(LoginModel request)
    {
        var user = ValidateUser(request.Username);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var hashedPassword = HashPassword(request.Password);
        if (user.Password != hashedPassword)
        {
            throw new Exception("Password not valid");
        }

        // GENERATE TOKEN

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("this is a secret from appsettings");

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
                    new Claim("Id", $"{user.Id}"),
                }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                //SecurityAlgorithms.Aes128CbcHmacSha256
                SecurityAlgorithms.HmacSha256Signature)

        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new UserDto
        {
            FullName = $"{user.FirstName} {user.LastName}",
            Id = user.Id,
            Token = tokenHandler.WriteToken(token)
        };
    }

    private User? ValidateUser(string username)
    {
        return _users
                   .FirstOrDefault(x => x.Username
                         .Equals(username,
                               StringComparison.InvariantCultureIgnoreCase));
    }

    private static bool ValidatePassword(string password)
    {
        foreach (var character in password)
        {
            if (char.IsDigit(character))
            {
                return true;
            }
        }
        return false;
    }

    private static string HashPassword(string password)
    {
        var md5 = new MD5CryptoServiceProvider();
        var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
        var hashedPassword = Encoding.ASCII.GetString(md5data);
        return hashedPassword;
    }
}
