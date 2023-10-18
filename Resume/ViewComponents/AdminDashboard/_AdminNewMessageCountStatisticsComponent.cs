using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.AdminRepositories.StatisticsRepositories;

namespace Resume.ViewComponents.AdminDashboard
{

    public class _AdminNewMessageCountStatisticsComponent : ViewComponent
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public _AdminNewMessageCountStatisticsComponent(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _statisticsRepository.GetNewMessageCount();
            ViewBag.Count = count;
            return View();
        }
    }

}