using MovieApp.ServiceModels.UserServiceModels;

namespace MovieApp.Services.Interfaces;

public interface IUserService
{
    void Register(RegisterUserDto request);
    UserLoginDto Login(LoginModel request);
}
