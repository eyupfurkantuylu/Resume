using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AdminDtos.AboutDtos;

namespace Resume.Repositories.AdminRepositories.AboutRepositories
{

    public class AdminAboutRepository : IAdminAboutRepository
    {
        private readonly Context _context;

        public AdminAboutRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetAdminAboutDto> GetAboutData()
        {
            string query = "SELECT * FROM About";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<GetAdminAboutDto>(query);
                return result;
            }
        }

        public async Task UpdateAboutData(GetAdminAboutDto adminAboutDto)
        {
            string query = "UPDATE About " +
                           "SET Name = @Name, " +
                           "    Surname = @Surname, " +
                           "    Address = @Address, " +
                           "    Email = @Email, " +
                           "    Phone = @Phone, " +
                           "    Description = @Description, " +
                           "    ImageUrl = @ImageUrl " +
                           "WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", adminAboutDto.Name);
            parameters.Add("@Surname", adminAboutDto.Surname);
            parameters.Add("@Address", adminAboutDto.Address);
            parameters.Add("@Email", adminAboutDto.Email);
            parameters.Add("@Phone", adminAboutDto.Phone);
            parameters.Add("@Description", adminAboutDto.Description);
            parameters.Add("@ImageUrl", adminAboutDto.ImageUrl);
            parameters.Add("@ID", adminAboutDto.ID);

            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query, parameters);
            }
        }
    }

}