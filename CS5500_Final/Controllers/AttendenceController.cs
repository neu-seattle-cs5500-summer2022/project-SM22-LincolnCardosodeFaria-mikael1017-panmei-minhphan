//using CS5500_Final.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace CS5500_Final.Controllers
//{
//    [Produces("application/json")]
//    public class AttendenceController : Controller
//    {
//        /// <summary>
//        /// Create an attendence
//        /// </summary>
//        /// <param name="attendence"></param>
//        /// <returns></returns>
//        [HttpPost(nameof(CreateAttence))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
//        public async Task<HttpResponseMessage> CreateAttence(Attendence attendence)
//        {



//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }
//        /// <summary>
//        /// Update an attendence
//        /// </summary>
//        /// <param name="attendence"></param>
//        /// <returns></returns>
//        [HttpPut(nameof(UpdateAttendence))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
//        public async Task<HttpResponseMessage> UpdateAttendence(Attendence attendence)
//        {



//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }
//        /// <summary>
//        /// Get all attendence by an User
//        /// </summary>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        [HttpGet(nameof(GetAllAttendenceByUser))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
//        public async Task<HttpResponseMessage> GetAllAttendenceByUser(User user)
//        {



//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }


//    }
//}
