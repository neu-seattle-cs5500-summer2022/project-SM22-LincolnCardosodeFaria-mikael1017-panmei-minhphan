using CS5500_Final.Models;
using CS5500_Final.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CS5500_Final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : Controller
    {
        private readonly IConfiguration _configuration;
        public FoodController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Create a Food
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateFood))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<JsonResult> CreateFood(FoodViewModel food)
        {
            string myDb1ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (var connection = new SqlConnection(myDb1ConnectionString))
                {
                    await connection.OpenAsync();

                    var parameters = new { Name = food.name, QuantityLbs = food.quantityLbs };

                    var sqlStatement = @"
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

                    await connection.ExecuteAsync(sqlStatement, parameters);
                    return new JsonResult("Food Created")
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
        /// Update a Food
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateFood))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<JsonResult> UpdateFood(Food food)
        {
            return new JsonResult("User Found")
            {
                StatusCode = StatusCodes.Status200OK // Status code here 
            };
        }
        /// <summary>
        /// Get All Food by diet id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllDietByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<JsonResult> GetAllDietByUser(int dietId)
        {

            return new JsonResult("User Found")
            {
                StatusCode = StatusCodes.Status200OK // Status code here 
            };
        }
    }
}
