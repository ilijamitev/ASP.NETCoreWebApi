using Notes.DataAccess;
using Notes.DataModels.Models;
using Notes.ServiceModels.UserModels;
using Notes.Services.Interfaces;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Notes.Common.Models;

namespace Notes.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly string _secret;

        public UserService(IRepository<User> userRepository, IOptions<MyAppSettings> options)
        {
            _userRepository = userRepository;
            _secret = options.Value.Secret;
        }

        public void Register(RegisterUserDto request)
        {
            var user = _userRepository.GetAll()
                .SingleOrDefault(x => x.Username.Equals(request.Username, StringComparison.InvariantCultureIgnoreCase));

            if (user is not null)
            {
                throw new Exception("User already exists!");
            }

            if (!IsValidPassword(request.Password))
            {
                throw new Exception("Invalid password!");
            }

            var hashedPassword = HashPassword(request.Password);

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = hashedPassword,
                Username = request.Username
            };

            _userRepository.Insert(newUser);
        }


        public UserLoginDto Login(LoginModel request)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Username.Equals(request.Username, StringComparison.InvariantCultureIgnoreCase));

            ArgumentNullException.ThrowIfNull(user);

            var hashedPassword = HashPassword(request.Password);

            if (user.Password != hashedPassword)
            {
                throw new Exception("Invalid password!");
            }

            // ako kreirame token na poveke mesta t.e. imame poveke nacini na logiranje moze da se izvadi kako posebna metoda

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

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

            var loggedUser = new UserLoginDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Token = tokenHandler.WriteToken(token)
            };

            return loggedUser;
        }



        private bool IsValidPassword(string password)
        {
            var passwordRegex = new Regex(@"^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            var match = passwordRegex.Match(password);
            return match.Success;
        }

        private string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);
            return hashedPassword;
        }

    }
}
