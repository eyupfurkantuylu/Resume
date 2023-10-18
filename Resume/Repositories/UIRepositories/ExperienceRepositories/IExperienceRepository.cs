using Resume.Models.Dtos.ExperienceDtos;

namespace Resume.Repositories.UIRepositories.ExperienceRepositories
{

    public interface IExperienceRepository
    {
        Task<List<ResultExperienceDto>> GetAllExperience();
    }

}