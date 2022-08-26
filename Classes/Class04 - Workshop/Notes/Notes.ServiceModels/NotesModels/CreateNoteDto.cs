using Notes.ServiceModels.Enums;

namespace Notes.ServiceModels.NotesModels
{
    public class CreateNoteDto
    {
        public string Text { get; set; }
        public string Color { get; set; }
        public int Tag { get; set; }
        public int UserId { get; set; }
    }
}
