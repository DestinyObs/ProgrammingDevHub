using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProgrammingDevHub.Data.Enums;

namespace ProgrammingDevHub.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Language")]
        public int LangId { get; set; }
        public Languages? Language { get; set; }
        public ClubCategory ClubCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
