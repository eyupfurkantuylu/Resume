using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AdminDtos.HobbyDtos;

namespace Resume.Repositories.AdminRepositories.HobbyRepositories
{

    public class HobbyAdminRepository:IHobbyAdminRepository
    {
        private readonly Context _context;

        public HobbyAdminRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAdminHobbyDto>> GetHobbyData()
        {
            string query = "SELECT * FROM Hobby";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultAdminHobbyDto>(query);
                return result.ToList();
            }
        }

        public async Task<ResultAdminHobbyDto> GetHobbyById(int id)
        {
            string query = "SELECT * FROM Hobby WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);
            
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResultAdminHobbyDto>(query, parameters);
                return result;
            }
        }
        
        
        public async Task UpdateHobbyData(UpdateAdminHobbyDto updateAdminHobbyDto)
        {
            string query = "UPDATE Hobby " +
                           "SET Hobby = @Hobby " +
                           "WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@Hobby", updateAdminHobbyDto.Hobby);
            parameters.Add("@ID", updateAdminHobbyDto.ID);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query, parameters);
            }
        }
        
        public async Task CreateAdminHobbyRepository(CreateAdminHobbyDto createAdminHobbyDto)
        {
            string query = "INSERT INTO Hobby (Hobby) " +
                           "VALUES (@Hobby)";
            var parameters = new DynamicParameters();
            parameters.Add("@Hobby", createAdminHobbyDto.Hobby);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        
        
    }

}