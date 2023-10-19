using Resume.Models.Dtos.AdminDtos.ExperienceDtos;

namespace Resume.Repositories.AdminRepositories.ExperienceRepositories
{

    public interface IExperienceAdminRepository
    {
        Task<List<ResultAdminExperienceDto>> GetAllExperience();

    }

}