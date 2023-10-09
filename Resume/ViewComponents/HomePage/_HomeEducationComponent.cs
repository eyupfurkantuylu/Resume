using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.EducationRepositories;

namespace Resume.ViewComponents.HomePage
{

    public class _HomeEducationComponent:ViewComponent
    {
        
        private readonly IEducationRepository _educationRepository;

        public _HomeEducationComponent(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var educationResult = await _educationRepository.GetAllEducation();
            return View(educationResult);
        }
        
        
    }

}