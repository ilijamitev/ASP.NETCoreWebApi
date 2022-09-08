using Notes.ServiceModels.UserModels;

namespace Notes.Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUserDto request);
        UserLoginDto Login(LoginModel request);
    }
}
