using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.EducationDtos;
using Resume.Models.Dtos.ExperienceDtos;

namespace Resume.Repositories.UIRepositories.EducationRepositories
{

    public class EducationRepository:IEducationRepository
    {
        private readonly Context _context;

        public EducationRepository(Context context)
        {
            _context = context; 
        }
        
        public async Task<List<ResultAdminEducationDtos>> GetAllEducation()
        {
            string query = "Select * From Education";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAdminEducationDtos>(query);
                return values.ToList();
            }
        }
    }

}