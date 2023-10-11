using Resume.Models.Dtos.ContactDtos;

namespace Resume.Repositories.ContactRepositories
{

    public interface IContactRepository
    {
        Task<bool> CreateContact(CreateContactDto createContactDto);
    }

}