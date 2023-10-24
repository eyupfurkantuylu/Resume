using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AdminDtos.SkillDtos;

namespace Resume.Repositories.AdminRepositories.SkillRepositories
{

    public class SkillAdminRepository: ISkillAdminRepository
    {
        private readonly Context _context;

        public SkillAdminRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultAdminSkillDto>> GetAllSkill()
        {
            string query = "Select * From Skills";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAdminSkillDto>(query);
                return values.ToList();
            }
        }
        
        public async Task CreateAdminSkillRepository(CreateAdminSkillDto createAdminSkillDto)
        {
            string query = "INSERT INTO Skills (Skill, ImageUrl) " +
                           "VALUES (@Skill, @ImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@Skill", createAdminSkillDto.Skill);
            parameters.Add("@ImageUrl", createAdminSkillDto.ImageUrl);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        
        
        
        public async Task UpdateAdminSkillRepository(UpdateAdminSkillDto updateAdminSkillDto)
        {
            string query = "UPDATE Skills " +
                           "SET Skill = @Skill, " +
                           "    ImageUrl = @ImageUrl " +
                           "WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@Skill", updateAdminSkillDto.Skill);
            parameters.Add("@ImageUrl", updateAdminSkillDto.ImageUrl);
            parameters.Add("@ID", updateAdminSkillDto.ID);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query, parameters);
            }
        }
        
        public async Task<ResultAdminSkillDto> GetSkillById(int id)
        {
            string query = "SELECT * FROM Skills WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", id);
            
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResultAdminSkillDto>(query, parameters);
                return result;
            }
        }
        
    }

}
