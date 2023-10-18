using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.AdminRepositories.StatisticsRepositories;

namespace Resume.ViewComponents.AdminDashboard
{

    public class _AdminOpenedMessageCountStatisticsComponent:ViewComponent
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public _AdminOpenedMessageCountStatisticsComponent(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _statisticsRepository.GetOpenedMessageCount();
            ViewBag.Count = count;
            return View();
        }
        
        
        
    }

}