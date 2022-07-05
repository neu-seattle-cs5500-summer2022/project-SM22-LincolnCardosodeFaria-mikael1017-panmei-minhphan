using CS5500_Final.Models;
using CS5500_Final.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Cors;
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
        //[EnableCors("AllowAll")]
        /// <summary>
        /// Create an User
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateUser))]
        public async Task<JsonResult> CreateUser(UserViewModel data)
        {


            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();
                    List<User> resultUser = new List<User>();
                    var parameters = new { username = data.username };
                    var sqlStatementUser = @"
                                   select * from Users
                                    where username = @username";

                    resultUser = (await connection.QueryAsync<User>(sqlStatementUser, parameters)).ToList();

                    if (resultUser.Count == 0)
                    {
                        var sqlStatement = @"
                                    INSERT INTO Users 
                                    (username
                                    ,fullname
                                    ,password    
                                    ,email
                                    ,dob
                                    ,address
                                    ,phone
                                    )
                                    VALUES (@username
                                    ,@fullname
                                    ,@password
                                    ,@email
                                    ,@dob
                                    ,@address
                                    ,@phone
                                    )";

                        int result = await connection.ExecuteScalarAsync<int>(sqlStatement, data);

                        return new JsonResult("User Created")
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
                        };
                    }

                    else
                    {
                        return new JsonResult("username is unavailable")
                        {
                            StatusCode = StatusCodes.Status451UnavailableForLegalReasons // Status code here 
                        };
                    }
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


        /// <summary
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
