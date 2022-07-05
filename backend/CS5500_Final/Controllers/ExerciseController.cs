using CS5500_Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CS5500_Final.Controllers
{
    [Produces("application/json")]
    public class ExerciseController : Controller
    {
        /// <summary>
        /// Create an Exercise
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns></returns>
        [HttpPost(nameof(CreateExercise))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<HttpResponseMessage> CreateExercise(Exercise exercise)
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        /// <summary>
        /// Get All Exercises by User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetAllExerciseByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<HttpResponseMessage> GetAllExerciseByUser(int userId)
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        /// <summary>
        /// Update an exercise
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns></returns>
        [HttpPut(nameof(UpdateExerciseByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<HttpResponseMessage> UpdateExerciseByUser(Exercise exercise)
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
