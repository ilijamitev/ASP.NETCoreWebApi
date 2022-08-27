using Class08.DemoCode.AdoNet.Models;
using Class08.DemoCode.AdoNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class08.DemoCode.AdoNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        // IActionResult nema genericka varijanta
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            var noteService = new NoteService();
            noteService.Add("NEW TEXT", "NEW COLOR", 1, 1);
            var notes = noteService.GetAllNotes();
            return Ok(notes);
        }
    }
}
