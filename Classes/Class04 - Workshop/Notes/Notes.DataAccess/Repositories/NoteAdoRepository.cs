using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Notes.Common.Models;
using Notes.DataModels.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Notes.DataAccess.Repositories
{
    public class NoteAdoRepository : IRepository<Note>
    {
        private readonly string _connectionString;

        public NoteAdoRepository(IOptions<MyAppSettings> settings)
        {
            _connectionString = settings.Value.NotesAppDbConnection;
        }

        public int Delete(Note entity)
        {
            using SqlConnection connection = new(_connectionString);
            var sqlQuery = @"delete from dbo.Note where Id = @id";
            try
            {
                connection.Open();
                SqlCommand cmd = new(sqlQuery, connection);
                var rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Note> FilterBy(Func<Note, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetAll()
        {
            throw new NotImplementedException();
        }

        public Note GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Note entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Note entity)
        {
            using SqlConnection connection = new(_connectionString);

            var sqlQuery = @"UPDATE dbo.Notes SET Text = @noteText, Color = @noteColor, Tag=@noteTag, UserId = @noteUserId WHERE Id=@id";
            try
            {
                connection.Open();
                SqlCommand cmd = new(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@text", entity.Text);
                cmd.Parameters.AddWithValue("@noteColor", entity.Color);
                cmd.Parameters.AddWithValue("@noteTag", entity.Tag);
                cmd.Parameters.AddWithValue("@noteUserId", entity.UserId);

                var rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
