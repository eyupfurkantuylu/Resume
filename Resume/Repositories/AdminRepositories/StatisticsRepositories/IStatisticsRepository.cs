using Resume.Models.Dtos.AdminDtos.ContactDtos;
using Resume.Models.Dtos.AdminDtos.StatisticsDtos;
using Resume.Models.Dtos.StatiscticsDtos;

namespace Resume.Repositories.AdminRepositories.StatisticsRepositories
{

    public interface IStatisticsRepository
    {
        Task<int> GetAllMessageCount();
        Task<int> GetNewMessageCount();
        Task<int> GetOpenedMessageCount();
        Task<IEnumerable<GetMonthlyDataForContactDto>> GetMonthlyDataForContactByYear(int year);
        Task<List<GetAllContactsDataDto>> GetAllContactsDataRepository();
        Task<List<GetAllContactsDataDto>> GetAllTodaysContactDataRepository();
        Task<ContactDetailDto> GetContactDetailRepository(int id);
        Task ContactToggleStatus(int id);
    }

}