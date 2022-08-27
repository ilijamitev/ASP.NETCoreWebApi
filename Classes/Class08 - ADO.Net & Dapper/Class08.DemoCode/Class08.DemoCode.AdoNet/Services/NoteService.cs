using Class08.DemoCode.AdoNet.Models;
using System.Data.SqlClient;

namespace Class08.DemoCode.AdoNet.Services
{
    public class NoteService
    {
        private readonly string _connectionString = @"Server=.;Database=NotesApp_DB;Trusted_Connection=True";

        public IEnumerable<Note> GetAllNotes()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Select * from dbo.Note";
            SqlDataReader reader = cmd.ExecuteReader();

            List<Note> notes = new List<Note>();

            while (reader.Read())
            {
                var note = new Note
                {
                    Id = (int)reader["Id"],
                    Color = reader["Color"].ToString(),
                    Text = reader["Text"].ToString(),
                    Tag = (int)reader["Tag"],
                    UserId = (int)reader["UserId"]
                };
                notes.Add(note);
            }

            connection.Close();
            return notes;
        }

        public Note GetNoteByUserIdAndNoteId(int userId, int noteId)
        {
            string sqlInsert = $@"0;Insert into dbo.Note (Text,Color,Tag,UserId)
                                    VALUES('Test in','Red',4,1)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new();
                    cmd.Connection = connection;

                    // cmd.CommandText = $"select * from dbo.Note where Id = {sqlInsert}"; // za zastita ne se koristi vaka, zoso ako pratime vo forma nekoja sql komanda ke ja izvrsi komandata, a vaka so parameters (kako podole) ke go gleda samo kako parametar....
                    cmd.CommandText = "select * from dbo.Note where Id= @id and UserId = @userId";
                    cmd.Parameters.AddWithValue("@id", noteId);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Note note = null;
                    while (reader.Read())
                    {
                        note = new Note
                        {
                            Id = (int)reader["Id"],
                            Color = reader["Color"].ToString(),
                            Text = reader["Text"].ToString(),
                            Tag = (int)reader["Tag"],
                            UserId = (int)reader["UserId"]
                        };
                    }

                    return note;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            };

        }

        public void Add(string text, string color, int tag, int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new();
                    cmd.Connection = connection;

                    cmd.CommandText = "insert into dbo.Note (Text,Color,Tag,UserId)" +
                        "VALUES(@noteText,@noteColor,@noteTag,@userId)";
                    cmd.Parameters.AddWithValue("@noteText", text);
                    cmd.Parameters.AddWithValue("@noteColor", color);
                    cmd.Parameters.AddWithValue("@noteTag", tag);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            };
        }
    }
}
