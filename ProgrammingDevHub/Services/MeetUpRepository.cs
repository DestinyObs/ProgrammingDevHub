using Microsoft.EntityFrameworkCore;
using ProgrammingDevHub.Data;
using ProgrammingDevHub.Interfaces;
using ProgrammingDevHub.Models;

namespace ProgrammingDevHub.Services
{
    public class MeetUpRepository : IMeetUpRepository
    {
        private readonly ApplicationDbContext _Context;

        public MeetUpRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public bool Add(MeetUp meetUp)
        {
            _Context.Add(meetUp);
            return save();
        }

        public bool Delete(MeetUp meetUp)
        {
            _Context.Remove(meetUp);
            return save();
        }

        public async Task<IEnumerable<MeetUp>> GetAll()
        {
            return await _Context.MeetUps.ToListAsync();
        }

        public async Task<MeetUp> GetByIdAync(int id)
        {
            return await _Context.MeetUps.Include(i => i.Language).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MeetUp> GetByIdAyncNoTracking(int id)
        {
            return await _Context.MeetUps.Include(i => i.Language).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool Update(MeetUp meetUp)
        {
            _Context.Update(meetUp);
            return save();
        }
    }
}
