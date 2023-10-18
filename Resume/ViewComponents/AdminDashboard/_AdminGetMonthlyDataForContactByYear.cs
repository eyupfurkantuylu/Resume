using Microsoft.AspNetCore.Mvc;
using Resume.Repositories.AdminRepositories.StatisticsRepositories;

namespace Resume.ViewComponents.AdminDashboard
{

    public class _AdminGetMonthlyDataForContactByYear:ViewComponent
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public _AdminGetMonthlyDataForContactByYear(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(int year)
        {
            var result = await _statisticsRepository.GetMonthlyDataForContactByYear(year: year);

            int[] monthCounts = new int[12];

            foreach (var item in result)
            {
                if (int.TryParse(item.Month, out int month) && month >= 1 && month <= 12)
                {
                    monthCounts[month - 1] = item.Count;
                }
            }

            ViewBag.monthCounts = monthCounts;
            
            return View();
        }
        
    }

}