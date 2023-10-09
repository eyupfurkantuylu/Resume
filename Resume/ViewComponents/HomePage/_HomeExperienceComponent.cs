using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.ExperienceRepositories;

namespace Resume.ViewComponents.HomePage
{

    public class _HomeExperienceComponent:ViewComponent
    {
        private readonly IExperienceRepository _experienceRepository;

        public _HomeExperienceComponent(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var experienceResult = await _experienceRepository.GetAllExperience();
            return View(experienceResult);
        }
        
    }

}