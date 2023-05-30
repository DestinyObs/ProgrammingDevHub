using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProgrammingDevHub.Data.Enums;
using ProgrammingDevHub.ViewModel;

namespace ProgrammingDevHub.Models
{
    public class MeetUp : CreateMeetUpViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("Language")]
        public int LangId { get; set; }
        public Languages? Language { get; set; }
        public MeetUpCategory MeetUpCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
} 
