using Resume.Models.Dtos.AdminDtos.AwardsDtos;
using Resume.Models.Dtos.AwardsDtos;

namespace Resume.Repositories.AdminRepositories.AwardsRepositories
{

    public interface IAwardsAdminRepository
    {
        Task<List<ResultAwardListDto>> GetAwardData();
        Task<ResultAwardListDto> GetAwardById(int id);
        Task UpdateAwardData(UpdateAdminAwardDto updateAdminAwardDto);
        Task CreateAward(CreateAdminAwardDto createAdminAwardDto);
        Task DeleteAdminAwardRepository(int id);
    }

}