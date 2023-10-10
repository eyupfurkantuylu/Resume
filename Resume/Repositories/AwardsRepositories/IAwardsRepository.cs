using Resume.Models.Dtos.AwardsDtos;

namespace Resume.Repositories.AwardsRepositories
{

    public interface IAwardsRepository
    {
        Task<List<ResultAwardsDto>> GetAllAwards();
    }

}