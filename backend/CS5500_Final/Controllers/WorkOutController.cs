//using CS5500_Final.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace CS5500_Final.Controllers
//{
//    [Produces("application/json")]
//    public class WorkOutController : Controller
//    {
//        /// <summary>
//        /// Create a new Workout
//        /// </summary>
//        /// <param name="workout"></param>
//        /// <returns></returns>
//        [HttpPost(nameof(CreateWorkout))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
//        public async Task<HttpResponseMessage> CreateWorkout(Workout workout)
//        {
            

            
//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }
//        /// <summary>
//        /// Update a Workout
//        /// </summary>
//        /// <param name="workout"></param>
//        /// <returns></returns>
//        [HttpPut(nameof(UpdateWorkout))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
//        public async Task<HttpResponseMessage> UpdateWorkout(Workout workout)
//        {



//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }
//        /// <summary>
//        /// Get All Workouts for an User
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <returns></returns>
//        [HttpGet(nameof(GetAllWorkoutByUser))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
//        public async Task<HttpResponseMessage> GetAllWorkoutByUser(int userId)
//        {



//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }
//    }
//}
