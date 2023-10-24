using Resume.Models.Dtos.AdminDtos.SkillDtos;

namespace Resume.Repositories.AdminRepositories.SkillRepositories
{

    public interface ISkillAdminRepository
    {
        Task<List<ResultAdminSkillDto>> GetAllSkill();
        Task CreateAdminSkillRepository(CreateAdminSkillDto createAdminSkillDto);
        Task UpdateAdminSkillRepository(UpdateAdminSkillDto updateAdminSkillDto);
        Task<ResultAdminSkillDto> GetSkillById(int id);

    }

}