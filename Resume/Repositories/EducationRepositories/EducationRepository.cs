using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.EducationDtos;
using Resume.Models.Dtos.ExperienceDtos;

namespace Resume.Repositories.EducationRepositories
{

    public class EducationRepository:IEducationRepository
    {
        private readonly Context _context;

        public EducationRepository(Context context)
        {
            _context = context; 
        }
        
        public async Task<List<ResultEducationDtos>> GetAllEducation()
        {
            string query = "Select * From Education";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEducationDtos>(query);
                return values.ToList();
            }
        }
    }

}