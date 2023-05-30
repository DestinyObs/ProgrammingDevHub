using Microsoft.AspNetCore.Mvc;
using ProgrammingDevHub.Interfaces;
using ProgrammingDevHub.Migrations;
using ProgrammingDevHub.Models;
using ProgrammingDevHub.ViewModel;

namespace ProgrammingDevHub.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();

            if (ModelState.IsValid)
            {
                foreach (var user in users)
                {
                    int? phone = null;
                    if (!string.IsNullOrEmpty(user.PhoneNumber))
                    {
                        int parsedPhone;
                        if (int.TryParse(user.PhoneNumber, out parsedPhone))
                        {
                            phone = parsedPhone;
                        }
                    }

                    var userViewModel = new UserViewModel
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Language = user.Language,
                        Country = user.Country,
                        PhoneNumber = user.PhoneNumber, // Use the 'phone' variable here
                        PostalCode = user.PostalCode,
                        Gender = user.Gender,
                        State = user.State,
                        CountryCode = user.CountryCode,
                        GitHubName = user.GitHubName,
                        LevelOProgramming = user.LevelOProgramming,
                        YOExperience = user.YOExperience,
                    };

                    result.Add(userViewModel);
                }
            }

            return View(result);
        }

                
        public async Task<IActionResult> Detail(string Id)
        {
            var user = await _userRepository.GetUserById(Id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Language = user.Language,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber,
                PostalCode = user.PostalCode,
                Gender = user.Gender,
                State = user.State,
                CountryCode = user.CountryCode,
                GitHubName = user.GitHubName,
                LevelOProgramming = user.LevelOProgramming,
                YOExperience = user.YOExperience,
            };
            return View(userDetailViewModel);
        }

      
        
    }
}
