using Resume.Models.Dtos.HobbyDtos;

namespace Resume.Repositories.HobbyRepositories
{

    public interface IHobbyRepository
    {
        Task<List<ResultHobbyDto>> GetAllHobby();

    }

}