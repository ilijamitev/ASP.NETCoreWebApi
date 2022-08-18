using Notes.DataModels.Models;
using Notes.ServiceModels.NotesModels;

namespace Notes.Common.Mappers
{
    public static class Mapper
    {
        public static NoteDto MapToNoteDto(this Note note)
        {
            return new NoteDto
            {
                Color = note.Color,
                Id = note.Id,
                Tag = (TagType)note.Tag,
                Text = note.Text,
                UserId = note.UserId,
            };


        }
    }
}
