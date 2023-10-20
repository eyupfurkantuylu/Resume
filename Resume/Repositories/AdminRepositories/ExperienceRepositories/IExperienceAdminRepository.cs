using Resume.Models.Dtos.AdminDtos.ExperienceDtos;

namespace Resume.Repositories.AdminRepositories.ExperienceRepositories
{

    public interface IExperienceAdminRepository
    {
        Task<List<ResultAdminExperienceDto>> GetAllExperience();
        Task<ResultAdminExperienceDto> GetExperienceById(int id);
        Task UpdateAdminExperienceRepository(UpdateAdminExperienceDto updateAdminExperienceDto);
        Task CreateAdminExperienceRepository(CreateExperienceDto createExperienceDto);
        Task DeleteAdminExperienceRepository(int id);

    }

}