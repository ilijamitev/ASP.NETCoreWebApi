﻿using Notes.ServiceModels.Enums;

namespace Notes.ServiceModels.NotesModels
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType Tag { get; set; }

    }


}
