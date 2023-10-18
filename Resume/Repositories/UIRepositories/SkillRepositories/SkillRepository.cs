using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.ExperienceDtos;
using Resume.Models.Dtos.SkillDtos;

namespace Resume.Repositories.UIRepositories.SkillRepositories
{

    public class SkillRepository:ISkillRepository
    {
        private readonly Context _context;

        public SkillRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultSkillDto>> GetAllSkill()
        {
            string query = "Select * From Skills";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSkillDto>(query);
                return values.ToList();
            }
        }
    }

}