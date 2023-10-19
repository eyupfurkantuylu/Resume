using Resume.Models.Dtos.AdminDtos.AboutDtos;

namespace Resume.Repositories.AdminRepositories.AboutRepositories
{

    public interface IAdminAboutRepository
    {
        Task<GetAdminAboutDto> GetAboutData();
        Task UpdateAboutData(GetAdminAboutDto adminAboutDto);
    }

}