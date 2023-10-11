using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Resume.Models;
using Resume.Models.Dtos.ContactDtos;
using Resume.Repositories.AboutRepositories;
using Resume.Repositories.ContactRepositories;

namespace Resume.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAboutRepository _aboutRepository;
    private readonly IContactRepository _contactRepository;


    public HomeController(ILogger<HomeController> logger, IAboutRepository aboutRepository,
        IContactRepository contactRepository)
    {
        _logger = logger;
        _aboutRepository = aboutRepository;
        _contactRepository = contactRepository;
    }


    public async Task<IActionResult> Index()
    {
        var aboutResult = await _aboutRepository.GetLastAbout();
        ViewBag.UserImage = aboutResult.ImageUrl;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    

    [HttpPost]
    public async Task<IActionResult> SendContact(CreateContactDto createContactDto)
    {
        createContactDto.SendeDate = DateTime.Now;
        createContactDto.Status = true;
        var result = await _contactRepository.CreateContact(createContactDto);
        return Json(result);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}