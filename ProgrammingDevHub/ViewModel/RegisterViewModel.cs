using System.ComponentModel.DataAnnotations;

namespace ProgrammingDevHub.ViewModel
{
	public class RegisterViewModel
	{
		[Display(Name = "Email Address")]
		[Required(ErrorMessage = "Email Address Is Required")]
        public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Confirm Passwords")]
		[Required(ErrorMessage = "Password Confirmation is Required")]
		[Compare("Password", ErrorMessage = "Password Do Not Match")]
		public string ConfirmPassword { get; set; }
        public string State { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CountryCode { get; set; }
        public int? PostalCode { get; set; }
        public string GitHubName { get; set; }
        public string? YOExperience { get; set; }
        public string? LevelOProgramming { get; set; }
    }
}
