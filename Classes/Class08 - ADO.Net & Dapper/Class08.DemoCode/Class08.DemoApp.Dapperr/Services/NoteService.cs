using Class08.DemoCode.Dapperr.Models;
using Dapper;
using System.Data.SqlClient;

namespace Class08.DemoCode.Dapperr.Services
{
    public class NoteService
    {
        private readonly string _connectionString = @"Server=.;Database=NotesApp_DB;Trusted_Connection=True";

        public IEnumerable<Note> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlQuery = "select * from dbo.Note";
                var notes = connection.Query<Note>(sqlQuery);
                return notes;
                connection.Close();
            }
        }
    }
}
