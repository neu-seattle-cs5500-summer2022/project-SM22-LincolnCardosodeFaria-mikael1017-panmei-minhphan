using CS5500_Final.Models;
using CS5500_Final.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;

namespace CS5500_Final.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class DietController : Controller
    {
        private readonly IConfiguration _configuration;

        public DietController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Create a new diet for a user
        /// </summary>
        /// <param name="diet"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateDiet))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<JsonResult> CreateDiet(DietViewModel diet)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();


                    var parameters = new { WeekDay = diet.weekDay, UserId = diet.userId };
                    var sqlStatement = @"
                                    INSERT INTO Diets 
                                    (WeekDay
                                    ,UserId
                                    
                                    )
                                    VALUES (
                                     @WeekDay
                                    ,@UserId
                                    
      
                                    )";

                    var insertedDiet = await connection.QueryAsync<Diet>(sqlStatement, parameters);
                    

                    var sqlStatementLatestId = @"SELECT IDENT_CURRENT('Diets')";

                    var lastId =await connection.QueryAsync<int>(sqlStatementLatestId);
                    int id = lastId.FirstOrDefault();
                    foreach (var item in diet.Foods)
                    {
                        var parametersFood = new { DietId = lastId.FirstOrDefault(), QuantityLbs = item.quantityLbs, Name = item.name };
                        var sqlStatementFood = @"
                                    INSERT INTO Foods 
                                    (Name
                                    ,QuantityLbs
                                    ,DietId
                                    
                                    )
                                    VALUES (
                                     @Name
                                    ,@QuantityLbs
                                    ,@DietId        
                                    
      
                                    )";

                        await connection.QueryAsync<int>(sqlStatementFood, parametersFood);


                    }


                    return new JsonResult("Diet Created")
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
        /// Update and Diet
        /// </summary>
        /// <param name="diet"></param>
        /// <returns>Return Status 200 when success</returns>
        [HttpPut(nameof(UpdateDiet))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<HttpResponseMessage> UpdateDiet(Diet diet)
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        /// <summary>
        /// List all Diets for an User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>return a list of dieets for an User</returns>

        [HttpGet(nameof(GetAllDietsByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<HttpResponseMessage> GetAllDietsByUser(int userId)
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// List All Diets for a User for an specific month
        /// </summary>
        /// <param name="id"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllDietsByUserByMonth))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<HttpResponseMessage> GetAllDietsByUserByMonth(int id, int month)

        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
