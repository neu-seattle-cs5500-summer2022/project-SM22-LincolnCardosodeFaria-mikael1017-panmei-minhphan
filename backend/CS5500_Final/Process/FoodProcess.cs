using CS5500_Final.Models;
using Dapper;
using System.Data.SqlClient;

namespace CS5500_Final.Process
{
    public class FoodProcess
    {
        private readonly IConfiguration _configuration;

        public FoodProcess (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Food>> GetFoodsByDietId(int dietId)
        {

            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();


                    var parameters = new { DietId = dietId };
                    var sqlStatementQueryDit = @"select * from Foods
                                                 where DietId =@DietId";

                    return (await connection.QueryAsync<Food>(sqlStatementQueryDit, parameters)).ToList();

                 
                }
            }
            catch (Exception e)
            {
                throw;

            }

        }
    }
}
