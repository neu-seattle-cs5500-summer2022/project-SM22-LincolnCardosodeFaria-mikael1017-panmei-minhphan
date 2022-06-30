using CS5500_Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CS5500_Final.Controllers
{
    [Produces("application/json")]
    public class DietController : Controller
    {
        /// <summary>
        /// Create a new diet for a user
        /// </summary>
        /// <param name="diet"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateDiet))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<HttpResponseMessage> CreateDiet(Diet diet)
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
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
        /// <param name="user"></param>
        /// <returns>return a list of dieets for an User</returns>
        [HttpGet(nameof(GetAllDietsByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<HttpResponseMessage> GetAllDietsByUser(User user)
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
