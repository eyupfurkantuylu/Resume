using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AboutDtos;

namespace Resume.Repositories.AboutRepositories
{

    public class AboutRepository:IAboutRepository
    {
        private readonly Context _context;

        public AboutRepository(Context context)
        {
            _context = context; 
        }
        
        public async Task<List<ResultAboutDto>> GetAllAbout()
        {
            string query = "Select * From About";

            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultAboutDto>(query);
                return values.ToList();
            }
        }

        public async Task<LastAboutDto> GetLastAbout()
        {
            string query = "SELECT TOP 1 * FROM About ORDER BY ID DESC";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<LastAboutDto>(query);
                return result;
            }
            
        }
    }

}