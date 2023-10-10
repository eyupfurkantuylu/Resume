using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AwardsDtos;
using Resume.Models.Dtos.SkillDtos;

namespace Resume.Repositories.AwardsRepositories
{

    public class AwardsRepository:IAwardsRepository
    {
        private readonly Context _context;

        public AwardsRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAwardsDto>> GetAllAwards()
        {
            string query = "Select * From Awards";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAwardsDto>(query);
                return values.ToList();
            }
        }
    }

}