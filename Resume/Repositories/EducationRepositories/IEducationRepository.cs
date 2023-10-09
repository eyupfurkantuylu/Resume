using Resume.Models.Dtos.EducationDtos;

namespace Resume.Repositories.EducationRepositories
{

    public interface IEducationRepository
    {
        Task<List<ResultEducationDtos>> GetAllEducation();
    }

}