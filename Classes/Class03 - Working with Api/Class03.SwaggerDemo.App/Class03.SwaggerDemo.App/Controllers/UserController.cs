using Class03.SwaggerDemo.App.Model;
using Microsoft.AspNetCore.Mvc;

namespace Class03.SwaggerDemo.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IEnumerable<User> _users = new List<User>
        {
            new User
            {
                Id=1,
                Name="Ilija"
            }
        };

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>IEnumerable<User></returns>
        [HttpGet("all")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<UserDto>> GetUserByName([FromRoute] string? name)
        {
            return Ok(_users.Select(x => new UserDto { UserId = x.Id, FullName = x.Name }));
        }

        [HttpGet("filter")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 404)]
        [ProducesResponseType(typeof(int), 400)]
        [ProducesResponseType(typeof(int), 100)]
        public ActionResult<IEnumerable<UserDto>> GetFilteredUsers([FromQuery] SearchInput input)
        {
            return Ok(_users.Select(x => new UserDto { UserId = x.Id, FullName = x.Name }));
        }

        public class SearchInput
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
