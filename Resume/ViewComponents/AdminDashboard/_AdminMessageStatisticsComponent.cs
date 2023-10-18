using Microsoft.AspNetCore.Mvc;
using Resume.Models.Dtos.AdminDtos.StatisticsDtos;
using Resume.Repositories.AdminRepositories.StatisticsRepositories;

namespace Resume.ViewComponents.AdminDashboard
{

    public class _AdminMessageStatisticsComponent:ViewComponent
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public _AdminMessageStatisticsComponent(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = await _statisticsRepository.GetAllMessageCount();
            ViewBag.Count = count;
            return View();
        }
    }

}