using Microsoft.AspNetCore.Mvc;
using Resume.Models.Dtos.AdminDtos.AboutDtos;
using Resume.Models.Dtos.AdminDtos.ContactDtos;
using Resume.Models.Dtos.AdminDtos.EducationDtos;
using Resume.Models.Dtos.AdminDtos.ExperienceDtos;
using Resume.Models.Dtos.AdminDtos.StatisticsDtos;
using Resume.Repositories.AdminRepositories.AboutRepositories;
using Resume.Repositories.AdminRepositories.EducationRepositories;
using Resume.Repositories.AdminRepositories.ExperienceRepositories;
using Resume.Repositories.AdminRepositories.StatisticsRepositories;

namespace Resume.Controllers
{

    public class AdminController : Controller
    {
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IAdminAboutRepository _adminAboutRepository;
        private readonly IExperienceAdminRepository _experienceAdminRepository;
        private readonly IEducationAdminRepository _educationAdminRepository;
        public AdminController(IStatisticsRepository statisticsRepository, IAdminAboutRepository adminAboutRepository, IExperienceAdminRepository experienceAdminRepository, IEducationAdminRepository educationAdminRepository)
        {
            _statisticsRepository = statisticsRepository;
            _adminAboutRepository = adminAboutRepository;
            _experienceAdminRepository = experienceAdminRepository;
            _educationAdminRepository = educationAdminRepository;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        // All Contacts & Own Methods
        public async Task<IActionResult> AllContacts()
        {
            return View();
        }
        // All Contacts sayfası için tüm iletişim taleplerini döndüren metod
        public async Task<IActionResult> GetAllContactsDataJson()
        {
            List<GetAllContactsDataDto> result = await _statisticsRepository.GetAllContactsDataRepository();
            return Json(result);
        }
        // Bugünün iletişim verisini getirir
        public async Task<IActionResult> TodaysContact()
        {
            return View();
        }
        public async Task<IActionResult> GetAllTodaysContactDataJson()
        {
            List<GetAllContactsDataDto> result = await _statisticsRepository.GetAllTodaysContactDataRepository();
            return Json(result);
        }

        public async Task<IActionResult> ContactDetail(int id)
        {
            ContactDetailDto result = await _statisticsRepository.GetContactDetailRepository(id);
            return View(result);
        }

        public async Task<IActionResult> ContactToggleStatus(int id)
        {
            _statisticsRepository.ContactToggleStatus(id);
            return Json(new { success = true, message = "OK" });
        }

        [HttpGet]
        public async Task<IActionResult> About()
        {
            GetAdminAboutDto result = await _adminAboutRepository.GetAboutData();
            
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> About(GetAdminAboutDto adminAboutDto)
        {
            await _adminAboutRepository.UpdateAboutData(adminAboutDto);
            return RedirectToAction("About");
        }

        public async Task<IActionResult> Experience()
        {
            var result = await _experienceAdminRepository.GetAllExperience();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> ExperienceDetail(int id)
        {
            var result = await _experienceAdminRepository.GetExperienceById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> ExperienceDetail(UpdateAdminExperienceDto updateAdminExperienceDto)
        {
            await _experienceAdminRepository.UpdateAdminExperienceRepository(updateAdminExperienceDto);
            return RedirectToAction("Experience");
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateExperience(CreateExperienceDto createExperienceDto)
        {
            await _experienceAdminRepository.CreateAdminExperienceRepository(createExperienceDto);
            return RedirectToAction("Experience");
        }
        
     
        public async Task<IActionResult> DeleteExperience(int id)
        {
            await _experienceAdminRepository.DeleteAdminExperienceRepository(id);
            return Json(new { success = true, message = "OK" });
        }

        public async Task<IActionResult> Education()
        {
            var result = await _educationAdminRepository.GetAllEducationData();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> EducationDetail(int id)
        {
            var result = await _educationAdminRepository.GetEducationById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> EducationDetail(UpdateAdminEducationDto updateAdminEducationDto)
        {
            await _educationAdminRepository.UpdateAdminEducationRepository(updateAdminEducationDto);
            return RedirectToAction("Education");
        }
        
        public async Task<IActionResult> DeleteEducation(int id)
        {
            await _educationAdminRepository.DeleteAdminEducationRepository(id);
            return Json(new { success = true, message = "OK" });
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEducation(CreateAdminEducationDto createAdminEducationDto)
        {
            await _educationAdminRepository.CreateAdminEducationRepository(createAdminEducationDto);
            return RedirectToAction("Education");
        }
        
        
    }

}