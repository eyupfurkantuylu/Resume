using Resume.Models.Dtos.HobbyDtos;

namespace Resume.Repositories.UIRepositories.HobbyRepositories
{

    public interface IHobbyRepository
    {
        Task<List<ResultHobbyDto>> GetAllHobby();

    }

}