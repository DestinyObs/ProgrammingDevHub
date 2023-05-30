using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingDevHub.Interfaces;
using ProgrammingDevHub.Models;
using ProgrammingDevHub.ViewModel;

namespace ProgrammingDevHub.Controllers
{
    public class DashboardController : Controller
    {
        public readonly IDashboardRepository _dashboardRespository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public DashboardController(IDashboardRepository dashboardRespository, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _dashboardRespository = dashboardRespository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRespository.GetAllUserMeetUps();
            var userClubs = await _dashboardRespository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                MeetUps = userRaces,
                Clubs = userClubs
            };
            return View(dashboardViewModel);
        }
        public async Task<IActionResult> EditUserDashBoard()
        {
            string curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRespository.GetUserById(curUserId);
            if (user == null) { return View("Error"); }

            var editUserViewModel = new EditUserDashBoardViewModel()
            {
                Id = curUserId,
                one = user.one,
                two = user.two,
                ProfileImageUrl = user.ProfileImageUrl
            };
            return View(editUserViewModel);

        }

    }
}
