using Class03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class03.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly List<Note> _notes = new List<Note>()
    {
        new Note
        {
            Id=1,
            Text = "Buy milk",
            Color = "Green",
            UserId = 1,
        },
        new Note
        {
            Id =2,
            Text = "Walk dog",
            Color = "Orange",
            UserId = 2,
                    },
        new Note
        {
            Id = 3,
            Text = "Clean floor",
            Color = "Orange",
            UserId = 2,
                    }
    };

        [HttpGet("{id}")]
        public ActionResult<Note> GetById(int id)
        {
            var note = _notes.SingleOrDefault(x => x.Id == id);
            if (note == null)
            {
                return NotFound("Note does not exist");
            }
            return Ok(note);
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Note>> GetList([FromQuery] string? orderBy)
        {
            var notes = _notes;
            switch (orderBy)
            {
                case "Text":
                    notes = notes.OrderBy(x => x.Text).ToList();
                    break;
                case "Color":
                    notes = notes.OrderBy(x => x.Color).ToList();
                    break;
            }
            return Ok(notes);
        }


        [HttpGet("user/{userId}/notes")]
        public ActionResult<IEnumerable<Note>> GetNotesForUser([FromRoute] int? userId, [FromQuery] SearchNotesInput input)
        {
            var a = Request;
            var b = Response;
            var notes = _notes.Where(x => x.UserId == userId);
            if (!string.IsNullOrWhiteSpace(input.Color))
            {
                notes = notes.Where(x => x.Color == input.Color);
            }
            switch (input.OrderBy)
            {
                case "Text":
                    notes = notes.OrderBy(x => x.Text);
                    break;
                case "Color":
                    notes = notes.OrderBy(x => x.Color);
                    break;
            }
            return Ok(notes);
        }

        [HttpGet("user/{userId}/notesForUser")]
        public ActionResult<IEnumerable<Note>> GetNotesForLoggedUser([FromRoute] int? userId, [FromHeader] int? authenticateUser)
        {
            if (authenticateUser is null)
            {
                return Unauthorized();
            }
            if (authenticateUser != userId)
            {
                return Forbid(); //si logiran ama ne smees da pristapis
            }
            var notes = _notes.Where(x => x.UserId == userId);

            return Ok(notes);
            //return StatusCode(202, "Succesfull"); 
        }
    }

}
