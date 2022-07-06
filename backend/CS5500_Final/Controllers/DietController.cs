using CS5500_Final.Models;
using CS5500_Final.Process;
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


                    return new JsonResult(new { dietId = id, message = "Diet Created" })
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
        public async Task<JsonResult> UpdateDiet(Diet diet)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();

                                   
                    var sqlStatementQueryDit = @"select * from Diets where id = @DietId";
                    var selectParemeter = new { DietId = diet.id };
                    var selectedDiet = await connection.QueryAsync<Diet>(sqlStatementQueryDit, selectParemeter);

                    var updateParameters = new { DietId = diet.id, WeekDay = diet.weekDay, UserId = diet.userId };
                    string updateQuery = @"UPDATE Diets SET WeekDay = @WeekDay, UserId = @UserId WHERE id = @DietId";
                    await connection.QueryAsync<int>(updateQuery, updateParameters);

                    string updateFoodQuery = @"UPDATE Foods SET Name = @Name,  QuantityLbs = @QuantityLbs WHERE id = @FoodId";
                    foreach (var item in diet.foods)
                    {
                        var updateFoodParameters = new { Name = item.Name, QuantityLbs = item.QuantityLbs, FoodId = item.id };
                        await connection.QueryAsync<int>(updateFoodQuery, updateFoodParameters);
                    }

                    return new JsonResult("Diet Updated")
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
        /// List all Diets for an User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>return a list of dieets for an User</returns>

        [HttpGet(nameof(GetAllDietsByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<JsonResult> GetAllDietsByUser(int userId)
        {
            

            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();


                    var parameters = new { UserId = userId };
                    var sqlStatementQueryDit = @"select* from Diets where UserId = @UserId";

                    var selectedDiets = await connection.QueryAsync<Diet>(sqlStatementQueryDit, parameters);

                    if (selectedDiets.Count() > 0)
                    {
                        FoodProcess process = new FoodProcess(_configuration);
                        
                        foreach (var item in selectedDiets)
                        {
                            item.foods = await process.GetFoodsByDietId(item.id);

                            
                        }


                        return new JsonResult(selectedDiets)
                        {
                            StatusCode = StatusCodes.Status200OK // Status code here 
                        };
                    }
                    else
                    {
                        return new JsonResult("Diets related to this user id not found")
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
        /// List All Diets for a User for an specific month
        /// </summary>
        /// <param name="id"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        //[HttpGet(nameof(GetAllDietsByUserByMonth))]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        //public async Task<HttpResponseMessage> GetAllDietsByUserByMonth(int id, int month)

        //{



        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}
    }
}
