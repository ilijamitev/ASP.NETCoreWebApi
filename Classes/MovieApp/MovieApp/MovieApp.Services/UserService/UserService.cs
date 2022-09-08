using Microsoft.Extensions.Options;
using MovieApp.DataAccess.Repositories.Interfaces;
using MovieApp.Domain.Models;
using MovieApp.Helpers.Models;
using MovieApp.ServiceModels.UserServiceModels;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services.UserService;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly string _secret;
    public UserService(IRepository<User> userRepository, IOptions<MyConfigurations> options)
    {
        _userRepository = userRepository;
        _secret = options.Value.Secret;
    }
    public UserLoginDto Login(LoginModel request)
    {
        throw new NotImplementedException();
    }

    public void Register(RegisterUserDto request)
    {
        throw new NotImplementedException();
    }
}
