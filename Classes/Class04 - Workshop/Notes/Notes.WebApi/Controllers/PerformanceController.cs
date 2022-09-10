using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.Services.Interfaces;
using System.Diagnostics;

namespace Notes.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly Stopwatch _stopwatch;
        private readonly INoteService _noteService;
        public PerformanceController(INoteService noteService)
        {
            _noteService = noteService;
            _stopwatch = new Stopwatch();
        }

        [HttpGet]
        [Route("notes")]
        [AllowAnonymous]
        public ActionResult<long> GetNotesPerformance()
        {
            _stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                _noteService.GetNote(1, 1);
            }
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.ElapsedMilliseconds;
            return elapsedTime;
        }
    }
}
