using Resume.Models.Dtos.AdminDtos.HobbyDtos;

namespace Resume.Repositories.AdminRepositories.HobbyRepositories
{

    public interface IHobbyAdminRepository
    {
        Task<List<ResultAdminHobbyDto>> GetHobbyData();
        Task UpdateHobbyData(UpdateAdminHobbyDto updateAdminHobbyDto);
        Task CreateAdminHobbyRepository(CreateAdminHobbyDto createAdminHobbyDto);
        Task<ResultAdminHobbyDto> GetHobbyById(int id);
        Task DeleteHobby(int id);
    }

}