using Resume.Models.Dtos.ExperienceDtos;

namespace Resume.Repositories.ExperienceRepositories
{

    public interface IExperienceRepository
    {
        Task<List<ResultExperienceDto>> GetAllExperience();
    }

}