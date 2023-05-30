using System.ComponentModel.DataAnnotations;

namespace ProgrammingDevHub.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address Is Required")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
	}
}
