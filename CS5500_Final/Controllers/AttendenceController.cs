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
    public class AttendenceController : Controller
    {
        private readonly IConfiguration _configuration;

        public AttendenceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Create an attendence
        /// </summary>
        /// <param name="attendence"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateAttence))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<JsonResult> CreateAttence(AttendenceViewModel attendence)
        {

            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();


                    var parameters = new { Day  = attendence.day, Time = attendence.time, SpentTime = attendence.spentTime, Date = attendence.date, UserId = attendence.UserId };
                    var sqlStatement = @"
                                    INSERT INTO Attendences 
                                    (date
                                    ,day
                                    ,time
                                    ,UserId
                                    ,spentTime
                                    
                                    )
                                    VALUES (
                                     @Date
                                    ,@Day
                                    ,@Time
                                    ,@UserId
                                    ,@spentTime
      
                                    )";

                    var insertedDiet = await connection.QueryAsync<Attendence>(sqlStatement, parameters);


                    var sqlStatementLatestId = @"SELECT IDENT_CURRENT('Attendences')";

                    var lastId = await connection.QueryAsync<int>(sqlStatementLatestId);
                    int id = lastId.FirstOrDefault();



                    return new JsonResult(new { attendencesId = id, message = "Attendence created" })
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
        /// Update an attendence
        /// </summary>
        /// <param name="attendence"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateAttendence))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<JsonResult> UpdateAttendence(Attendence attendence)
        {

            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
            


                    await connection.OpenAsync();

                    var sqlStatementQueryDit = @"select * from Attendences where id = @AttendenceId";
                    var selectParemeter = new { AttendenceId = attendence.id };
                    var selectedDiet = await connection.QueryAsync<Workout>(sqlStatementQueryDit, selectParemeter);

                    var updateParameters = new { AttendenceId = attendence.id,Time = attendence.time, SpentTime = attendence.spentTime, Date = attendence.date, UserId = attendence.UserId, Day = attendence.day };
                    string updateQuery = @"UPDATE Attendences 
                                         SET 
                                         date = @Date, 
                                         day = @Day,
                                         time =@Time, 
                                         spentTime =@SpentTime ,
                                         UserId =@UserId
                                         WHERE id = @AttendenceId";
                    await connection.QueryAsync<int>(updateQuery, updateParameters);


                    return new JsonResult("Attendence Updated")
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
        /// Get all attendence by an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllAttendenceByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<JsonResult> GetAllAttendenceByUser(int userId)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();


                    var parameters = new { UserId = userId };
                    var sqlStatementQueryDit = @"select* from Attendences where UserId = @UserId";

                    var selectedAttendencess = await connection.QueryAsync<Attendence>(sqlStatementQueryDit, parameters);

               
                    if (selectedAttendencess.Count() > 0)
                    {
                        return new JsonResult(selectedAttendencess)
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
                        };
                    }
                    else
                    {
                        return new JsonResult("Attendencess related to this user id not found")
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
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

        /// <summary>
        /// Get the last 30 days of attendance by user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetLast30DaysAttendenceByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<JsonResult> GetLast30DaysAttendenceByUser(int userId)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();


                    var parameters = new { UserId = userId };

                    var sqlStatementQueryDit = @"SELECT * FROM  Attendences 
                                                WHERE DATEDIFF(day,date,GETDATE()) between 0 and 30
                                                and UserId = @UserId";

                    var selectedAttendencess = await connection.QueryAsync<Attendence>(sqlStatementQueryDit, parameters);


                    if (selectedAttendencess.Count() > 0)
                    {
                        return new JsonResult(selectedAttendencess)
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
                        };
                    }
                    else
                    {
                        return new JsonResult("Attendencess related to this user id not found")
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
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

    }
}
