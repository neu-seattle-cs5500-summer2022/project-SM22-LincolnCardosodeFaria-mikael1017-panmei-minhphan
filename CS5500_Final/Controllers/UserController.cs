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
    //[Produces("application/json")]
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
        public async Task<JsonResult> CreateUser(UserViewModel data)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    List<User> resultUser = await GetUser(data.username, connection);
                    List<User> resultUserEmail = await GetUserEmail(data.email, connection);

                    if (resultUser.Count == 0 && resultUserEmail.Count == 0)
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
                                    ,isadmin
                                    )
                                    VALUES (@username
                                    ,@fullname
                                    ,@password
                                    ,@email
                                    ,@dob
                                    ,@address
                                    ,@phone
                                    ,@isadmin
                                    )";

                        int result = await connection.ExecuteScalarAsync<int>(sqlStatement, data);


                        List<User> userCreated = await GetUser(data.username, connection);

                        await connection.CloseAsync();

                        return new JsonResult(new { userId = userCreated.FirstOrDefault().id, message = "User Created" })
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
                        };
                    }

                    else
                    {
                        await connection.CloseAsync();

                        if (resultUser.Count > 0)
                        {
                            return new JsonResult(new { username = data.username, email = data.email, message = "User already exists" })
                            {
                                StatusCode = StatusCodes.Status409Conflict // Status code here 
                            };
                        }
                        else
                        {
                            return new JsonResult(new { username = data.username, email = data.email, message = "Email already exists" })
                            {
                                StatusCode = StatusCodes.Status409Conflict // Status code here 
                            };
                        }
                      
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

        private async Task<List<User>> GetUserEmail(string email, SqlConnection connection)
        {
            List<User> resultUser = new List<User>();
            var parameters = new { Email = email };
            var sqlStatementUser = @"
                                   select * from Users
                                    where email = @Email";

            resultUser = (await connection.QueryAsync<User>(sqlStatementUser, parameters)).ToList();
            return resultUser;
        }

        private static async Task<List<User>> GetUser(string username, SqlConnection connection)
        {
            List<User> resultUser = new List<User>();
            var parameters = new { username = username };
            var sqlStatementUser = @"
                                   select * from Users
                                    where username = @username";

            resultUser = (await connection.QueryAsync<User>(sqlStatementUser, parameters)).ToList();
            return resultUser;
        }

        /// <summary>
        /// Return All Users
        /// </summary>
        /// <returns></returns>
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet(nameof(GetAllUsers))]
        public async Task<JsonResult> GetAllUsers()
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();

                    string getAllUsers = @"select * from Users";

                    var selectedUser = await connection.QueryAsync<User>(getAllUsers);

                    return new JsonResult(selectedUser)
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
        /// <summary>
        /// Update an User
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost(nameof(UpdateUser))]
        public async Task<JsonResult> UpdateUser(User data)
        {

            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();

                    var updateUsersParameters = new

                    {
                        UserId = data.id,
                        Username = data.username,
                        Fullname = data.fullname,
                        Email = data.email,
                        Password = data.password,
                        DOB = data.dob,
                        Address = data.address,
                        Phone = data.phone

                    };
                    string updateFoodQuery = @"UPDATE Users SET username = @Username,  fullname = @Fullname , email = @Email, password = @Password, dob =@DOB , address = @Address, phone = @Phone WHERE id = @UserId";
                    await connection.QueryAsync<int>(updateFoodQuery, updateUsersParameters);

                    return new JsonResult("User Updated")
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

        /// <summary>
        /// Get a User
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetUserById))]
        public async Task<JsonResult> GetUserById(int id)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();

                    var getUsersParameters = new { UserId = id };
                    string getAllUsers = @"select * from Users WHERE id = @UserId";

                    var selectedUser = await connection.QueryAsync<User>(getAllUsers, getUsersParameters);

                    return new JsonResult(selectedUser)
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
