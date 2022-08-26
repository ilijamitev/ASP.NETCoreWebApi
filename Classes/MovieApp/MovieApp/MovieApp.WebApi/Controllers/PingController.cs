using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace MovieApp.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet("/ping")]
        public ActionResult CheckApiServerStatus()
        {
            try
            {
                Ping ping = new();
                PingReply result = ping.Send(@"https://localhost:7041/");
                Console.WriteLine(result.Status);
                Console.WriteLine(result.Address.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
