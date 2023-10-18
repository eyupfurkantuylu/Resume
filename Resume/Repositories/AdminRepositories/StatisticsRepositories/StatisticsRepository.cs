using System.Data;
using Dapper;
using Resume.Models.DapperContext;
using Resume.Models.Dtos.AboutDtos;
using Resume.Models.Dtos.AdminDtos.ContactDtos;
using Resume.Models.Dtos.AdminDtos.StatisticsDtos;
using Resume.Models.Dtos.ContactDtos;
using Resume.Models.Dtos.StatiscticsDtos;

namespace Resume.Repositories.AdminRepositories.StatisticsRepositories
{

    public class StatisticsRepository:IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> GetAllMessageCount()
        {
            string query = "Select COUNT(*) From Contact";

            using(var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteScalarAsync<int>(query);
                return result;
            }
        }

        public async Task<int> GetNewMessageCount()
        {
            string query = "SELECT COUNT(*) FROM Contact WHERE Status = 1";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteScalarAsync<int>(query);
                return result;
            }
        }

        public async Task<int> GetOpenedMessageCount()
        {
            string query = "SELECT COUNT(*) FROM Contact WHERE Status = 0";
            
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteScalarAsync<int>(query);
                return result;
            }
        }

        public async Task<IEnumerable<GetMonthlyDataForContactDto>> GetMonthlyDataForContactByYear(int year)
        {
            var parameters = new { Year = year };
            using (var connection = _context.CreateConnection())
            {
                
                var result = await connection.QueryAsync<GetMonthlyDataForContactDto>("GetMonthlyDataForContacts", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<GetAllContactsDataDto>> GetAllContactsDataRepository()
        {
            string query = "SELECT * FROM Contact";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<GetAllContactsDataDto>(query);
                return result.ToList();
            }
        }
        
        public async Task<List<GetAllContactsDataDto>> GetAllTodaysContactDataRepository()
        {
            DateTime today = DateTime.Now.Date;
            string query = "SELECT * FROM Contact WHERE CAST(SendDate AS DATE) = @Today AND Status = 0";
            var parameters = new DynamicParameters();
            parameters.Add("@Today", today);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<GetAllContactsDataDto>(query,parameters);
                return result.ToList();
            }
        }


        public async Task<ContactDetailDto> GetContactDetailRepository(int id)
        {
            string query = "SELECT * FROM Contact WHERE ID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ContactDetailDto>(query,parameters);
                return result;
            }
        }

        public async Task ContactToggleStatus(int id)
        {
            string query = "UPDATE Contact SET STATUS = " +
                           "CASE WHEN STATUS = 1 THEN 0 " +
                           "WHEN STATUS = 0 THEN 1 " +
                           "END " +
                           "WHERE ID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id",id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
            
        }
    }

}