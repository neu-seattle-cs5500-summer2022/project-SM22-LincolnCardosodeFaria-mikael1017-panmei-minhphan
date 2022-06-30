using CS5500_Final.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;

namespace CS5500_Final.Controllers
{
    [Produces("application/json")]
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
        /// <summary>
        /// Create an User
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateUser))]
        public async Task<int> CreateUser(User data)
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
                                    ,Password    
                                    )
                                    VALUES (@Name
                                    ,@Type
                                    ,@Password
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


        /// <summary>
        /// Return All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAllUsers))]
        public async Task<HttpResponseMessage> GetAllUsers()
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        /// <summary>
        /// Update an User
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost(nameof(UpdateUser))]
        public async Task<HttpResponseMessage> UpdateUser(User data)
        {

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Get a User
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetUserById))]
        public async Task<HttpResponseMessage> GetUserById(int Id)
        {
            var tt = new HttpResponseMessage(HttpStatusCode.OK);

            //return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(SerializedString, System.Text.Encoding.UTF8, "application/json") };

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
