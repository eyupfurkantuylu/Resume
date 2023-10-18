using Resume.Models.Dtos.AwardsDtos;

namespace Resume.Repositories.UIRepositories.AwardsRepositories
{

    public interface IAwardsRepository
    {
        Task<List<ResultAwardsDto>> GetAllAwards();
    }

}