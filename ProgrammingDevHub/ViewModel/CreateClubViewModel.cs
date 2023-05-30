using ProgrammingDevHub.Data.Enums;
using ProgrammingDevHub.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingDevHub.ViewModel
{
    public class CreateClubViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Languages Language { get; set; }
        public IFormFile Image { get; set; }
        public ClubCategory ClubCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
