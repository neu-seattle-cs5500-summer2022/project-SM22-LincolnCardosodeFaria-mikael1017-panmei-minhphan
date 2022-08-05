using CS5500_Final.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;

namespace CS5500_Final.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller

    {
        private readonly IConfiguration _configuration;


        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        ///  Request a user authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns if the authentication was a success or not.</returns>
        [HttpPost(nameof(Login))]
        public async Task<JsonResult> Login(Login user)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                List<User> result = new List<User>();
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new { username = user.username, password = user.password };
                    var sqlStatement = @"
                                   select * from Users
                                    where password  = @password
                                    and username = @username";

                    result = (await connection.QueryAsync<User>(sqlStatement, parameters)).ToList();
                }

                if (result.Count >= 1)
                {
                    return new JsonResult(new { UserId = result.FirstOrDefault().id, Admin = result.FirstOrDefault().isadmin, Authentication = true, Message = "User Authenticated" })
                    {
                        StatusCode = StatusCodes.Status200OK // Status code here 
                    };
                }
                else
                {
                    return new JsonResult(new { Authentication = false, Message = "User Not Authenticated" })
                    {
                        StatusCode = StatusCodes.Status200OK // Status code here 
                    };
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError // Status code here 
                };

            }

        }  
        
    }
}
