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

        [HttpGet(nameof(GetAllExerciseByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<HttpResponseMessage> GetAllExerciseByUser(int userId)
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut(nameof(UpdateExerciseByUser))]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<HttpResponseMessage> UpdateExerciseByUser(Exercise exercise)
        {



            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
