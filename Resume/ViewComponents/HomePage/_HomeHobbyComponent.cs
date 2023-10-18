using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.UIRepositories.HobbyRepositories;

namespace Resume.ViewComponents.HomePage
{

    public class _HomeHobbyComponent:ViewComponent
    {
        private readonly IHobbyRepository _hobbyRepository;

        public _HomeHobbyComponent(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var hobbyResult = await _hobbyRepository.GetAllHobby();
            return View(hobbyResult);
        }
    }

}