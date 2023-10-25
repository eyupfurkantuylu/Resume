using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AdminDtos.AwardsDtos;
using Resume.Models.Dtos.AwardsDtos;

namespace Resume.Repositories.AdminRepositories.AwardsRepositories
{

    public class AwardsAdminRepository: IAwardsAdminRepository
    {
        private readonly Context _context;

        public AwardsAdminRepository(Context context)
        {
            _context = context;
        }


        public async Task<List<ResultAwardListDto>> GetAwardData()
        {
            string query = "SELECT * FROM Awards";

            using (var connection =  _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultAwardListDto>(query);
                return result.ToList();
            }
        }
        
        public async Task UpdateAwardData(UpdateAdminAwardDto updateAdminAwardDto)
        {
            string query = "UPDATE Awards " +
                           "SET Awards = @Awards " +
                           "WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@Awards", updateAdminAwardDto.Awards);
            parameters.Add("@ID", updateAdminAwardDto.ID);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query, parameters);
            }
        }

        public async Task CreateAward(CreateAdminAwardDto createAdminAwardDto)
        {
            string query = "INSERT INTO Awards (Awards) " +
                           "VALUES (@Awards)";
            var parameters = new DynamicParameters();
            parameters.Add("@Awards", createAdminAwardDto.Awards);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultAwardListDto> GetAwardById(int id)
        {
            string query = "SELECT * FROM Awards WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResultAwardListDto>(query, parameters);
                return result;
            }
            
        }



    }

}