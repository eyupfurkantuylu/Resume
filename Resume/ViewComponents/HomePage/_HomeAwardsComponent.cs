using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.UIRepositories.AwardsRepositories;

namespace Resume.ViewComponents.HomePage
{

    public class _HomeAwardsComponent:ViewComponent
    {
        private readonly IAwardsRepository _awardsRepository;

        public _HomeAwardsComponent(IAwardsRepository awardsRepository)
        {
            _awardsRepository = awardsRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var awardsResult = await _awardsRepository.GetAllAwards();
            return View(awardsResult);
        }
    }

}