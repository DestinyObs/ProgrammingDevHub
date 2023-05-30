using Microsoft.EntityFrameworkCore;
using ProgrammingDevHub.Data;
using ProgrammingDevHub.Interfaces;
using ProgrammingDevHub.Models;
using System.Text.RegularExpressions;

namespace ProgrammingDevHub.Services
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _Context;

        public ClubRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public bool Add(Club club)
        {
            _Context.Add(club);
            return save();
        }

        public bool Delete(Club club)
        {
            _Context.Remove(club);
            return save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _Context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAync(int id)
        {

            return await _Context.Clubs.Include(i => i.Language).FirstOrDefaultAsync(x => x.Id == id);
        }

        public  async Task<Club> GetByIdAyncNoTracking(int id)
        {
            return await _Context.Clubs.Include(i => i.Language).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool save()
        {
            var saved = _Context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool Update(Club club)
        {
            _Context.Update(club);
            return save();
        }
    }
}


