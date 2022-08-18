using Notes.DataModels.Models;

namespace Notes.DataAccess
{
    public static class InMemoryDb
    {
        public static List<User> Users { get; set; } = new List<User>() { new User
        {
            FirstName="Ilija",
            LastName = "Mitev",
            Id = 1,
            NoteList = new List<Note>(),
            Password= "1234",
            Username = "ilija123"
        }
        };

        public static List<Note> Notes { get; set; } = new List<Note>()
        {
            new Note
            {
                Id = 1,
                Color = "Green",
                Text = "Hello",
                UserId = 1,
                User = new User
            {
            FirstName="Ilija",
            LastName = "Mitev",
            Id = 1,
            NoteList = new List<Note>(),
            Password= "1234",
            Username = "ilija123"
            }
            },
            new Note
            {
                Id = 2,
                Color = "Red",
                Text = "Bye",
                UserId = 1,
                User = new User
            {
            FirstName="Ilija",
            LastName = "Mitev",
            Id = 1,
            NoteList = new List<Note>(),
            Password= "1234",
            Username = "ilija123"
            }
            },


        };

    }
}
