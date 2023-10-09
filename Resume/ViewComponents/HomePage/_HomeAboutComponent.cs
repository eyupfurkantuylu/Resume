using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.AboutRepositories;

namespace Resume.ViewComponents.HomePage
{

    public class _HomeAboutComponent : ViewComponent
    {
        private readonly IAboutRepository _aboutRepository;

        public _HomeAboutComponent(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutResult = await _aboutRepository.GetLastAbout();
            return View(aboutResult);
        }
    }

}