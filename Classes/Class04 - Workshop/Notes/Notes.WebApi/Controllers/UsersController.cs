using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.ServiceModels.UserModels;
using Notes.Services.Interfaces;

namespace Notes.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult RegisterUser([FromBody] RegisterUserDto request)
        {
            try
            {
                _userService.Register(request);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
                throw;
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<UserLoginDto> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var user = _userService.Login(loginModel);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }


    }
}
