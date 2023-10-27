using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AuthDtos;

namespace Resume.Repositories.AdminRepositories.AuthRepositories
{

    public class AuthRepository:IAuthRepository
    {
        private readonly Context _context;

        public AuthRepository(Context context)
        {
            _context = context;
        }


        public async Task<AuthResultDto> Login(AdminLoginDto adminLoginDto)
        {
            string query = "SELECT * FROM Admin WHERE Email = @Email AND Password = @Password";
            var parameters = new DynamicParameters();
            parameters.Add("@Email", adminLoginDto.Email);
            parameters.Add("@Password", adminLoginDto.Password);
            
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<AdminLoginDto>(query, parameters);
                if (user != null)
                {
                    if (user.Password == adminLoginDto.Password)
                    {
                        return new AuthResultDto { Success = true, Message = "OK", ID=user.ID, Email = user.Email, Password = user.Password};
                    }
                    else
                    {
                        return new AuthResultDto { Success = false, Message = "Şifre hatalı." };
                    }
                }
                else
                {
                    return new AuthResultDto { Success = false, Message = "Kullanıcı adı bulunamadı." };
                }
            }
        }
    }

}