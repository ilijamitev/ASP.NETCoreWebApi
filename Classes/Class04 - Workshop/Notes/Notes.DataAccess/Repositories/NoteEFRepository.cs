using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Data;
using Notes.DataModels.Models;

namespace Notes.DataAccess.Repositories
{
    public class NoteEFRepository : IRepository<Note>
    {
        private readonly NotesDbContext _context;
        public NoteEFRepository(NotesDbContext context)
        {
            _context = context;
        }
        public int Delete(Note entity)
        {
            _context.Notes.Remove(entity);
            return entity.Id;
        }

        public IEnumerable<Note> FilterBy(Func<Note, bool> filter)
        {
            return _context.Notes.Where(filter);
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes;
        }

        public Note GetById(int id)
        {
            return _context.Notes.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Note entity)
        {
            _context.Notes.Add(entity);
            _context.SaveChanges(); // moze da se izvadi kako posebna metoda i na kraj da se iskoristi, primer ako sakame poveke notes da vneseme, da ne bide toa edna pa pisi vo baza pa druga....
            return entity.Id;
        }

        public int Update(Note entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            _context.Notes.Update(entity);
            _context.SaveChanges();
            return entity.Id;
        }
    }
}
