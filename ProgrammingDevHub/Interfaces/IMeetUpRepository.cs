using ProgrammingDevHub.Models;

namespace ProgrammingDevHub.Interfaces
{
    public interface IMeetUpRepository
    {
        Task<IEnumerable<MeetUp>> GetAll();
        Task<MeetUp> GetByIdAync(int id);
        Task<MeetUp> GetByIdAyncNoTracking(int id);
        bool Add(MeetUp meetUp);
        bool Update(MeetUp meetUp);
        bool Delete(MeetUp meetUp);
        bool save();
    }
}
