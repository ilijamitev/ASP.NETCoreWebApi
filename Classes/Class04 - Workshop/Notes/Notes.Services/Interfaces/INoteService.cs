using Notes.ServiceModels.NotesModels;

namespace Notes.Services.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetUserNotes(int userId);
        NoteDto GetNote(int id, int userId);
        void AddNote(CreateNoteDto note, int userId);
        void DeleteNote(int id, int userId);
    }
}
