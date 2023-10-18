using Resume.Models.Dtos.AboutDtos;

namespace Resume.Repositories.UIRepositories.AboutRepositories
{

    public interface IAboutRepository
    {
        Task<List<ResultAboutDto>> GetAllAbout();
        Task<LastAboutDto> GetLastAbout();
    }

}