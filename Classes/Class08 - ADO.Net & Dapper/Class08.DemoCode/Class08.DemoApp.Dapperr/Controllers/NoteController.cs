using Class08.DemoCode.Dapperr.Models;
using Class08.DemoCode.Dapperr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class08.DemoCode.Dapperr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NoteService _noteService;
        public NoteController()
        {
            _noteService = new NoteService();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            var notes = _noteService.GetAll();
            return Ok(notes);
        }

        [HttpGet("getById")]
        public ActionResult<IEnumerable<Note>> GetById()
        {
            var note = _noteService.GetByUserIdAndNoteId(1, 3);
            return Ok(note);
        }

        [HttpPost("add")]
        public ActionResult<IEnumerable<Note>> AddNote()
        {
            _noteService.Add("New Note", "ORANGE", 2, 3);
            return Ok();
        }
    }
}
