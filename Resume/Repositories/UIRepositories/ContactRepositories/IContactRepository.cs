using Resume.Models.Dtos.ContactDtos;

namespace Resume.Repositories.UIRepositories.ContactRepositories
{

    public interface IContactRepository
    {
        Task<bool> CreateContact(CreateContactDto createContactDto);
    }

}