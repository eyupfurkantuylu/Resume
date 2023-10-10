using Resume.Models.Dtos.SkillDtos;

namespace Resume.Repositories.SkillRepositories
{

    public interface ISkillRepository
    {
        Task<List<ResultSkillDto>> GetAllSkill();
    }

}