using ProgrammingDevHub.Models;
using System.Text.RegularExpressions;

namespace ProgrammingDevHub.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club> GetByIdAync(int id);
        Task<Club> GetByIdAyncNoTracking(int id);
        bool Add(Club club);
        bool Update(Club club);
        bool Delete(Club club);
        bool save();
    }
}
