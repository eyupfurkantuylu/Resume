using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AdminDtos.EducationDtos;
using Resume.Models.Dtos.EducationDtos;

namespace Resume.Repositories.AdminRepositories.EducationRepositories
{

    public class EducationAdminRepository:IEducationAdminRepository
    {
        private readonly Context _context;

        public EducationAdminRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAdminEducationDtos>> GetAllEducationData()
        {
            string query = "SELECT * FROM Education";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultAdminEducationDtos>(query);
                return result.ToList();
            }
        }

        public async Task<ResultAdminEducationDtos> GetEducationById(int id)
        {
            string query = "SELECT * FROM Education WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);
            
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResultAdminEducationDtos>(query, parameters);
                return result;
            }
        }
        
        public async Task UpdateAdminEducationRepository(UpdateAdminEducationDto updateAdminEducationDto)
        {
            string query = "UPDATE Education " +
                           "SET Title = @Title, " +
                           "    Subtitle = @Subtitle, " +
                           "    Description = @Description, " +
                           "    GPA = @GPA, " +
                           "    EducationDate = @EducationDate " +
                           "WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", updateAdminEducationDto.Title);
            parameters.Add("@Subtitle", updateAdminEducationDto.Subtitle);
            parameters.Add("@Description", updateAdminEducationDto.Description);
            parameters.Add("@GPA", updateAdminEducationDto.GPA);
            parameters.Add("@EducationDate", updateAdminEducationDto.EducationDate);
            parameters.Add("@ID", updateAdminEducationDto.ID);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query, parameters);
            }
        }

        public async Task DeleteAdminEducationRepository(int id)
        {
            string query = "DELETE FROM Education " +
                           "WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        
        public async Task CreateAdminEducationRepository(CreateAdminEducationDto createAdminEducation)
        {
            string query = "INSERT INTO Education (Title, Subtitle, Description, GPA, EducationDate) " +
                           "VALUES (@Title, @Subtitle, @Description, @GPA, @EducationDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createAdminEducation.Title);
            parameters.Add("@Subtitle", createAdminEducation.Subtitle);
            parameters.Add("@Description", createAdminEducation.Description);
            parameters.Add("@GPA", createAdminEducation.GPA);
            parameters.Add("@EducationDate", createAdminEducation.EducationDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        
        
    }

}