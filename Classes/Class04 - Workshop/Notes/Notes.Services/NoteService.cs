using Notes.Common.Mappers;
using Notes.DataAccess;
using Notes.DataModels.Models;
using Notes.ServiceModels.NotesModels;
using Notes.Services.Interfaces;
using System.Dynamic;

namespace Notes.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IRepository<User> _userRepository;

        public NoteService(IRepository<Note> noteRepository, IRepository<User> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public void AddNote(CreateNoteDto createNote)
        {
            var user = _userRepository.GetById(createNote.UserId);
            ArgumentNullException.ThrowIfNull(user, "User not found");
            var note = new Note
            {
                Text = createNote.Text,
                UserId = createNote.UserId,
                Color = createNote.Color,
                Tag = createNote.Tag,
            };
            _noteRepository.Insert(note);
        }

        public void DeleteNote(int id, int userId)
        {
            var note = _noteRepository.FilterBy(x => x.Id == id && x.UserId == userId).SingleOrDefault();
            ArgumentNullException.ThrowIfNull(note);
            _noteRepository.Delete(note);
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
