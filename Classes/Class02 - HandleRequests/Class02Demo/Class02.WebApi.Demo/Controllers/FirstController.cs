using Microsoft.AspNetCore.Mvc;

namespace Class02.WebApi.Demo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FirstController : ControllerBase
    {
        private List<string> _names = new List<string> { "Trajan", "Vlatko", "Stefaan" };

        [HttpGet]
        public int GetRandomInteger()
        {
            return 1;
        }

        [HttpGet("name/{id}")]
        public ActionResult GetName(int id)
        {
            Thread.Sleep(10000);
            try
            {
                var name = _names[id];
                return Ok(name);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }




    }
}
