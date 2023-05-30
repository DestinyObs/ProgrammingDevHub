using Microsoft.AspNetCore.Mvc;
using ProgrammingDevHub.Data;
using ProgrammingDevHub.Interfaces;
using ProgrammingDevHub.Models;
using ProgrammingDevHub.Services;
using ProgrammingDevHub.ViewModel;

namespace ProgrammingDevHub.Controllers
{
    public class MeetUpController : Controller
    {
        private readonly IMeetUpRepository _MeetUpRepository;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IPhotoService _photoService;

        public MeetUpController(IMeetUpRepository meetUpRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _MeetUpRepository = meetUpRepository;
            _photoService = photoService;
            _HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<MeetUp> meetUps = await _MeetUpRepository.GetAll();
            return View(meetUps);
        }

        public async Task<IActionResult> Detail(int Id)
        {
            MeetUp meetUps = await _MeetUpRepository.GetByIdAync(Id);
            return View(meetUps);
        }
        public IActionResult Create()
        {
            var curUser = _HttpContextAccessor.HttpContext.User.GetUserId();
            var CreateMeetUpViewModel = new CreateMeetUpViewModel { AppUserId = curUser };
            return View(CreateMeetUpViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetUpViewModel MeetUpViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(MeetUpViewModel.Image);
                if (result != null)
                {
                    var MeetUp = new MeetUp
                    {
                        Id = MeetUpViewModel.Id,
                        Title = MeetUpViewModel.Title,
                        Description = MeetUpViewModel.Description,
                        Image = result.Url.ToString(),
                        AppUserId = MeetUpViewModel.AppUserId,
                        Language = new Languages
                        {
                            Language = MeetUpViewModel.Language.Language,
                            Description = MeetUpViewModel.Language.Description,
                        }
                    };

                    _MeetUpRepository.Add(MeetUp);
                    return RedirectToAction("Index");

                }
                else { return NotFound(); }
            }
            else
            {
                ModelState.AddModelError("", "Photo Uplaod Failed");
            }
            return View(MeetUpViewModel);

        }

        public async Task<IActionResult> Edit(int Id)
        {
            var MeetUp = await _MeetUpRepository.GetByIdAync(Id);
            if (MeetUp == null) return View("Error");
            var EditMeetUpViewModel  = new EditMeetUpViewModel
            {
                Title = MeetUp.Title,
                Description = MeetUp.Description,
                LangId = MeetUp.LangId,
                Language = MeetUp.Language,
                URL = MeetUp.Image,
                MeetUpCategory = MeetUp.MeetUpCategory,
            };
            return View(EditMeetUpViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, EditMeetUpViewModel EditMeetUpViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors in the form, failed to EDIT group");
                return View(EditMeetUpViewModel);
            }

            var userMeetUp = await _MeetUpRepository.GetByIdAyncNoTracking(Id);
            if (userMeetUp != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userMeetUp.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delte Photo");
                    return View(EditMeetUpViewModel);
                }
                var photoResult = await _photoService.AddPhotoAsync(EditMeetUpViewModel.Image);
                var MeetUp = new MeetUp
                {
                    Id = Id,
                    Title = EditMeetUpViewModel.Title,
                    Description = EditMeetUpViewModel.Description,
                    LangId = EditMeetUpViewModel.LangId,
                    Language = EditMeetUpViewModel.Language,
                    Image = photoResult.Url.ToString(),
                    MeetUpCategory = EditMeetUpViewModel.MeetUpCategory,
                };
                _MeetUpRepository.Update(MeetUp);

                return RedirectToAction("Index");
            }
            else
            {
                return View(EditMeetUpViewModel);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var clubDetails = await _MeetUpRepository.GetByIdAync(id);
            if (clubDetails == null) return View("Error");
            return View(clubDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var clubDetails = await _MeetUpRepository.GetByIdAync(id);

            if (clubDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(clubDetails.Image))
            {
                _ = _photoService.DeletePhotoAsync(clubDetails.Image);
            }

            _MeetUpRepository.Delete(clubDetails);
            return RedirectToAction("Index");
        }
    }
}
