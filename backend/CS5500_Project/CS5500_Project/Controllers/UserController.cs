using CS5500_Project.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CS5500_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        [ActivatorUtilitiesConstructor]
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpPost(nameof(Create))]
        public async Task<int> Create(User data)
        {
            int resultId = 99999;
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();
                    var sqlStatement = @"
                                    INSERT INTO Users 
                                    (Name
                                    ,Type
                                    )
                                    VALUES (@Name
                                    ,@Type
                                    )";

                    resultId = await connection.ExecuteScalarAsync<int>(sqlStatement, data);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return resultId;
        }
    }
}
