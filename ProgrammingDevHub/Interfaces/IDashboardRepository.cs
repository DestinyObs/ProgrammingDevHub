using ProgrammingDevHub.Models;

namespace ProgrammingDevHub.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<MeetUp>> GetAllUserMeetUps();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
