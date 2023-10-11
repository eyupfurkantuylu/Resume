using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.ContactDtos;

namespace Resume.Repositories.ContactRepositories
{

    public class ContactRepository:IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> CreateContact(CreateContactDto createContactDto)
        {
            string query = "INSERT INTO Contact (Email,Subject,Message,SendDate,Status) values (@email,@subject,@message,@senddate,@status)";
            var parameters = new DynamicParameters();
            
            parameters.Add("@email", createContactDto.Email);
            parameters.Add("@subject", createContactDto.Subject);
            parameters.Add("@message", createContactDto.Message);
            parameters.Add("@senddate", createContactDto.SendeDate);
            parameters.Add("@status", createContactDto.Status);
            using(var connection = _context.CreateConnection())
            {
                int rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
        }
    }

}