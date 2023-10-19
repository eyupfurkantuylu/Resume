using System.Text;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resume.Models.Dtos.AdminDtos.AboutDtos;
using Resume.Models.Dtos.AdminDtos.ContactDtos;
using Resume.Models.Dtos.AdminDtos.StatisticsDtos;
using Resume.Models.Dtos.ContactDtos;
using Resume.Repositories.AdminRepositories.AboutRepositories;
using Resume.Repositories.AdminRepositories.StatisticsRepositories;

namespace Resume.Controllers
{

    public class AdminController : Controller
    {
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IAdminAboutRepository _adminAboutRepository;
        public AdminController(IStatisticsRepository statisticsRepository, IAdminAboutRepository adminAboutRepository)
        {
            _statisticsRepository = statisticsRepository;
            _adminAboutRepository = adminAboutRepository;
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
        
        
    }

}