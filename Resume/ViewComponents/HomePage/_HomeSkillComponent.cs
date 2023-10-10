using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.SkillRepositories;

namespace Resume.ViewComponents.HomePage
{

    public class _HomeSkillComponent:ViewComponent
    {
        private readonly ISkillRepository _skillRepository;

        public _HomeSkillComponent(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var skillResult = await _skillRepository.GetAllSkill();
            return View(skillResult);
        }
    }

}