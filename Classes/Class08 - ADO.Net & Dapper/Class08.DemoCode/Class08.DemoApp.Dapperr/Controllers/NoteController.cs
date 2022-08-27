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
        [HttpGet]
        public ActionResult<IEnumerable<Note>> GetAllNotes()
        {
            var notes = _noteService.GetAll();
            return Ok(notes);
        }
    }
}
