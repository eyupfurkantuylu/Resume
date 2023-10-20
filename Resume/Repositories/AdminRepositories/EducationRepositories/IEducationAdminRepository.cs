using Resume.Models.Dtos.AdminDtos.EducationDtos;
using Resume.Models.Dtos.AdminDtos.ExperienceDtos;
using Resume.Models.Dtos.EducationDtos;

namespace Resume.Repositories.AdminRepositories.EducationRepositories
{

    public interface IEducationAdminRepository
    {
        Task<List<ResultAdminEducationDtos>> GetAllEducationData();
        Task<ResultAdminEducationDtos> GetEducationById(int id);
        Task UpdateAdminEducationRepository(UpdateAdminEducationDto updateAdminEducationDto);
        Task DeleteAdminEducationRepository(int id);
        Task CreateAdminEducationRepository(CreateAdminEducationDto createAdminEducationDto);
    }

}