using Notes.Common.Mappers;
using Notes.DataAccess;
using Notes.DataModels.Models;
using Notes.ServiceModels.NotesModels;
using Notes.Services.Interfaces;

namespace Notes.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public NoteDto GetNote(int id, int userId)
        {
            var note = _noteRepository.FilterBy(x => x.Id == id && x.UserId == id).FirstOrDefault();
            ArgumentNullException.ThrowIfNull(note);
            return note.MapToNoteDto();
        }

        public IEnumerable<NoteDto> GetUserNotes(int userId)
        {
            var userNotes = _noteRepository.FilterBy(x => x.UserId == userId).Select(x => x.MapToNoteDto());
            ArgumentNullException.ThrowIfNull(userNotes);
            return userNotes;

        }
    }
}
