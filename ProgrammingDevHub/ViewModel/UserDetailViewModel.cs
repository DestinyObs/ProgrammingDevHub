using ProgrammingDevHub.Models;

namespace ProgrammingDevHub.ViewModel
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Languages? Language { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string Gender { get; set; }
        public int? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CountryCode { get; set; }
        public string GitHubName { get; set; }
        public string? YOExperience { get; set; }
        public string? LevelOProgramming { get; set; }
    }
}
