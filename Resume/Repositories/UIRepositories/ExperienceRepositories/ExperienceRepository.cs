using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.ExperienceDtos;

namespace Resume.Repositories.UIRepositories.ExperienceRepositories
{

    public class ExperienceRepository:IExperienceRepository
    {
        private readonly Context _context;

        public ExperienceRepository(Context context)
        {
            _context = context; 
        }

        public async Task<List<ResultExperienceDto>> GetAllExperience()
        {
            string query = "Select * From Experience";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultExperienceDto>(query);
                return values.ToList();
            }
        }
    }

}