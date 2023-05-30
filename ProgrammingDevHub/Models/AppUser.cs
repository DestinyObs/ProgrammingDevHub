using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ProgrammingDevHub.Models
{
    public class AppUser : IdentityUser
    {

        //public string? UserName { get; set; }
        public Languages? Language { get; set; }
        [ForeignKey("Language")]
        public int? LangId { get; set; }
        public string State { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public int? PostalCode { get; set; }
        public int? CountryCode { get; set; }
        public string GitHubName { get; set; }
        public string? YOExperience { get; set; }
        public string? LevelOProgramming { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<MeetUp> MeetUp { get; set; }
    }
}
