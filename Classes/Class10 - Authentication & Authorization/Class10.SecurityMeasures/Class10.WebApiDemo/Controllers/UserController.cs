using Class10.WebApiDemo.Models;
using Class10.WebApiDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Class10.WebApiDemo.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]  //ovie metodi nemaat avtorizacija
    [HttpPost("register")]
    public ActionResult Register([FromBody] RegisterModel request)
    {
        try
        {
            _userService.Register(request);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [AllowAnonymous] //ovie metodi nemaat avtorizacija
    [HttpPost("login")]
    public ActionResult<UserDto> Login(LoginModel request)
    {
        try
        {
            var user = _userService.Login(request);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }
}
