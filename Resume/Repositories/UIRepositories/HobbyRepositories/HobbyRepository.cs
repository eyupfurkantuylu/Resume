using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.HobbyDtos;
using Resume.Models.Dtos.SkillDtos;

namespace Resume.Repositories.UIRepositories.HobbyRepositories
{

    public class HobbyRepository:IHobbyRepository
    {
        private readonly Context _context;

        public HobbyRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultHobbyDto>> GetAllHobby()
        {
            string query = "Select * From Hobby";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultHobbyDto>(query);
                return values.ToList();
            }
        }
    }

}