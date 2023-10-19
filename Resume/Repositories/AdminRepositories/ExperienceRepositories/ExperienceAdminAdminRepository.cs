using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AdminDtos.ExperienceDtos;
using Resume.Models.Dtos.ExperienceDtos;

namespace Resume.Repositories.AdminRepositories.ExperienceRepositories
{

    public class ExperienceAdminAdminRepository:IExperienceAdminRepository
    {
        private readonly Context _context;

        public ExperienceAdminAdminRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAdminExperienceDto>> GetAllExperience()
        {
            string query = "Select * From Experience";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAdminExperienceDto>(query);
                return values.ToList();
            }
        }
    }

}