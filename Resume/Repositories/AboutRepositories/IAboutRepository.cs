using Resume.Models.Dtos.AboutDtos;

namespace Resume.Repositories.AboutRepositories
{

    public interface IAboutRepository
    {
        Task<List<ResultAboutDto>> GetAllAbout();
        Task<LastAboutDto> GetLastAbout();
    }

}