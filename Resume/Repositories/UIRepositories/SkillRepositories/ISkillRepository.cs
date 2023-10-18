using Resume.Models.Dtos.SkillDtos;

namespace Resume.Repositories.UIRepositories.SkillRepositories
{

    public interface ISkillRepository
    {
        Task<List<ResultSkillDto>> GetAllSkill();
    }

}