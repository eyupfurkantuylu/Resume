using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Resume.Models;
using Resume.Repositories.AboutRepositories;

namespace Resume.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAboutRepository _aboutRepository;


    public HomeController(ILogger<HomeController> logger, IAboutRepository aboutRepository)
    {
        _logger = logger;
        _aboutRepository = aboutRepository;
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}