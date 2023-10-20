using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AdminDtos.ExperienceDtos;
using Resume.Models.Dtos.ExperienceDtos;

namespace Resume.Repositories.AdminRepositories.ExperienceRepositories
{

    public class ExperienceAdminRepository:IExperienceAdminRepository
    {
        private readonly Context _context;

        public ExperienceAdminRepository(Context context)
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

        public async Task<ResultAdminExperienceDto> GetExperienceById(int id)
        {
            string query = "SELECT * FROM Experience WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);
            
            using (var connection = _context.CreateConnection())
            {
               var result = await connection.QueryFirstOrDefaultAsync<ResultAdminExperienceDto>(query, parameters);
               return result;
            }
        }

        public async Task UpdateAdminExperienceRepository(UpdateAdminExperienceDto updateAdminExperienceDto)
        {
            string query = "UPDATE Experience " +
                           "SET Title = @Title, " +
                           "    Subtitle = @Subtitle, " +
                           "    Description = @Description, " +
                           "    ExperienceDate = @ExperienceDate " +
                           "WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", updateAdminExperienceDto.Title);
            parameters.Add("@Subtitle", updateAdminExperienceDto.Subtitle);
            parameters.Add("@Description", updateAdminExperienceDto.Description);
            parameters.Add("@ExperienceDate", updateAdminExperienceDto.ExperienceDate);
            parameters.Add("@ID", updateAdminExperienceDto.ID);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query, parameters);
            }
        }

        public async Task CreateAdminExperienceRepository(CreateExperienceDto createExperienceDto)
        {
            string query = "INSERT INTO Experience (Title, Subtitle, Description, ExperienceDate) " +
                           "VALUES (@Title, @Subtitle, @Description, @ExperienceDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createExperienceDto.Title);
            parameters.Add("@Subtitle", createExperienceDto.Subtitle);
            parameters.Add("@Description", createExperienceDto.Description);
            parameters.Add("@ExperienceDate", createExperienceDto.ExperienceDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAdminExperienceRepository(int id)
        {
            string query = "DELETE FROM Experience " +
                           "WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }

}