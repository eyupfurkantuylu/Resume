using Resume.Models.Dtos.EducationDtos;

namespace Resume.Repositories.UIRepositories.EducationRepositories
{

    public interface IEducationRepository
    {
        Task<List<ResultEducationDtos>> GetAllEducation();
    }

}