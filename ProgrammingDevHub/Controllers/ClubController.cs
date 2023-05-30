using Microsoft.AspNetCore.Mvc;
using ProgrammingDevHub.Data;
using ProgrammingDevHub.Interfaces;
using ProgrammingDevHub.Models;
using ProgrammingDevHub.Services;
using ProgrammingDevHub.ViewModel;
using System.Text.RegularExpressions;

namespace ProgrammingDevHub.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _ClubRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _HttpContextAccessor;

        public ClubController(IClubRepository clubRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _ClubRepository = clubRepository;
            _photoService = photoService;
            _HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> Club = await _ClubRepository.GetAll();
            return View(Club);
        }

        public async Task<IActionResult> Detail(int Id)
        {
            Club Club = await _ClubRepository.GetByIdAync(Id);
            return View(Club);
        }

        public IActionResult Create()
        {
            var curUser = _HttpContextAccessor.HttpContext.User.GetUserId();
            var CreateClubViewModel = new CreateClubViewModel { AppUserId = curUser };
            return View(CreateClubViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel ClubViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(ClubViewModel.Image);
                if (result != null)
                {
                    var group = new Club
                    {
                        Id = ClubViewModel.Id,
                        Title = ClubViewModel.Title,
                        Description = ClubViewModel.Description,
                        Image = result.Url.ToString(),
                        AppUserId = ClubViewModel.AppUserId,
                        Language = new Languages
                        {
                            Language = ClubViewModel.Language.Language,
                            Description = ClubViewModel.Language.Description,
                        }
                    };

                    _ClubRepository.Add(group);
                    return RedirectToAction("Index");

                }
                else { return NotFound(); }
            }
            else
            {
                ModelState.AddModelError("", "Photo Uplaod Failed");
            }
            return View(ClubViewModel);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var Club = await _ClubRepository.GetByIdAync(Id);
            if (Club == null) return View("Error");
            var clubViewModel = new EditClubViewModel
            {
                Title = Club.Title,
                Description = Club.Description,
                LangId = Club.LangId,
                Language = Club.Language,
                URL = Club.Image,
                ClubCategory = Club.ClubCategory,
            };
            return View(clubViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, EditClubViewModel EditClubViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors in the form, failed to EDIT group");
                return View(EditClubViewModel);
            }

            var userGroup = await _ClubRepository.GetByIdAyncNoTracking(Id);
            if (userGroup != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userGroup.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delte Photo");
                    return View(EditClubViewModel);
                }
                var photoResult = await _photoService.AddPhotoAsync(EditClubViewModel.Image);
                var Club = new Club
                {
                    Id = Id,
                    Title = EditClubViewModel.Title,
                    Description = EditClubViewModel.Description,
                    LangId = EditClubViewModel.LangId,
                    Language = EditClubViewModel.Language,
                    Image = photoResult.Url.ToString(),
                    ClubCategory = EditClubViewModel.ClubCategory,
                };
                _ClubRepository.Update(Club);

                return RedirectToAction("Index");
            }
            else
            {
                return View(EditClubViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var clubDetails = await _ClubRepository.GetByIdAync(id);
            if (clubDetails == null) return View("Error");
            return View(clubDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var clubDetails = await _ClubRepository.GetByIdAync(id);

            if (clubDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(clubDetails.Image))
            {
                _ = _photoService.DeletePhotoAsync(clubDetails.Image);
            }

            _ClubRepository.Delete(clubDetails);
            return RedirectToAction("Index");
        }


    }
}
