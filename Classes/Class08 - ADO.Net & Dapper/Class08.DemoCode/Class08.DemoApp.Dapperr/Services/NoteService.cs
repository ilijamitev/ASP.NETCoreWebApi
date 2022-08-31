using Class08.DemoCode.Dapperr.Models;
using Dapper;
using System.Data.SqlClient;

namespace Class08.DemoCode.Dapperr.Services
{
    public class NoteService
    {
        private readonly IConfiguration _config;
        public NoteService(IConfiguration config)
        {
            _config = config;
        }

        public NoteService()
        {
        }

        public IEnumerable<Note> GetAll()
        {
            string connString = _config.GetConnectionString("NotesAppConnectionString");
            using SqlConnection connection = new(connString);
            connection.Open();
            var sqlQuery = "select * from dbo.Note";
            var notes = connection.Query<Note>(sqlQuery);
            return notes;
        }


        public Note GetByUserIdAndNoteId(int userId, int noteId)
        {
            using SqlConnection connection = new(_config.GetConnectionString("NotesAppConnectionString"));
            connection.Open();
            var sqlQuery = @"select * from dbo.Note 
                                where Id = @noteId and UserId = @userId";

            var note = connection
                .Query<Note>(
                    sqlQuery,
                    new
                    {
                        userId,
                        noteId
                    }).FirstOrDefault();

            return note;
        }

        public void Add(string text, string color, int tag, int userId)
        {
            using SqlConnection connection = new(_config.GetConnectionString("NotesAppConnectionString"));
            connection.Open();
            var sqlQuery = @"
                    INSERT INTO [dbo].[Note]([Text], [Color], [Tag], [UserId]) 
                    VALUES (@description, @boja, @tagType, @user)";

            connection.Query(sqlQuery,
                new
                {
                    description = text,
                    boja = color,
                    tagType = tag,
                    user = userId
                });
        }
    }
}
