using Resume.Models.Dtos.AuthDtos;

namespace Resume.Repositories.AdminRepositories.AuthRepositories
{

    public interface IAuthRepository
    {
        Task<AuthResultDto> Login(AdminLoginDto adminLoginDto);
    }

}