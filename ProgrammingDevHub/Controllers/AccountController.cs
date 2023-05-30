using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammingDevHub.Data;
using ProgrammingDevHub.Models;
using ProgrammingDevHub.ViewModel;

namespace ProgrammingDevHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = dbContext;
            
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) 
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if(user != null)
            {
                //user is found, check password
                var PassWordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (PassWordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }


                }
                //password is incorrect
                TempData["Error"] = "Wrong Password. Please Try Again";
                return View(loginViewModel);
            }
            //user not found 
            TempData["Error"] = "Incorrect or Wrong Username, Please Try Again";
            return View(loginViewModel);
        }


        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(registerViewModel);

			}
			var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if(user != null)
            {
                TempData["Error"] = "This Email Address Is already in use";
                return View(registerViewModel);
            }
            var newUser = new AppUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                PhoneNumber = registerViewModel.PhoneNumber,
                Country = registerViewModel.Country,
                Gender = registerViewModel.Gender,
                PostalCode = registerViewModel.PostalCode,
                GitHubName = registerViewModel.GitHubName,
                YOExperience = registerViewModel.YOExperience,
                LevelOProgramming = registerViewModel.LevelOProgramming,
                CountryCode = registerViewModel.CountryCode,
                State = registerViewModel.State,
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if(newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




    }
}
