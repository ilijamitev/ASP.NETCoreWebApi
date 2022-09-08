using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.ServiceModels.NotesModels;
using Notes.Services.Interfaces;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class NotesController : BaseController
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("user")]
        public ActionResult<IEnumerable<NoteDto>> GetNotes()
        {
            try
            {
                User.FindFirst(ClaimTypes.NameIdentifier);
                var notes = _noteService.GetUserNotes(UserId);
                return Ok(notes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public ActionResult<NoteDto> GetNoteById(int id)
        {
            try
            {
                var note = _noteService.GetNote(id, UserId);
                return StatusCode(200, note);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<NotesController>
        [HttpPost("create-note")]
        public ActionResult CreateNote([FromBody] CreateNoteDto newNote)
        {
            try
            {
                _noteService.AddNote(newNote, UserId);
                return StatusCode(StatusCodes.Status201Created, "Note created!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"ERROR MESSAGE: {ex.Message}");
            }
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
