using Class02.WebApi.Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class02.WebApi.Demo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly List<User> _users = new List<User>()
      {
          new User
          {
              Id = 1,
              Name = "Pink Panther",
              Age = 50,
              Gender = "M"
          },
          new User
          {
              Id = 2,
              Name = "Ilija",
              Age= 27,
              Gender = "M"
          },
          new User
          {
              Id=3,
              Name = "Kika",
              Age = 27,
              Gender = "F"

          }
      };

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            if (id < 1) return BadRequest(id);
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound($"User with id {id} does not exist.");
            return Ok(user);
        }

        [HttpGet("{id}/age")]
        public ActionResult<User> GetUserAge(int id)
        {
            if (id < 1) return BadRequest(id);
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound($"User with id {id} does not exist.");
            return Ok(user.Age);
        }

        [HttpGet("{name}/age/{age}")]
        public ActionResult<IEnumerable<User>> GetUsersByNameAndAge(int age, string name)
        {
            var users = _users.Where(x => x.Age == age && x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));    //CASE INSENSITIVE
            return Ok(users);
        }

        [HttpGet("gender/{gender}/age/{age}")]
        public ActionResult<IEnumerable<User>> GetUsersByNameAndAge(string gender, int age)
        {
            if (gender != "m" || age > 30) return BadRequest();
            var users = _users.Where(x => x.Age < 30 && x.Gender == "M");
            if (users == null) return BadRequest();
            return Ok(users);
        }

    }
}
