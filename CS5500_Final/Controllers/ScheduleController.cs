//using CS5500_Final.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace CS5500_Final.Controllers
//{
//    [Produces("application/json")]
//    public class ScheduleController : Controller
//    {/// <summary>
//    /// Create an Schedule
//    /// </summary>
//    /// <param name="schedule"></param>
//    /// <returns></returns>
//        [HttpPost(nameof(CreateSchedule))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
//        public async Task<HttpResponseMessage> CreateSchedule(Schedule schedule)
//        {



//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }
//        /// <summary>
//        /// update a schedule
//        /// </summary>
//        /// <param name="schedule"></param>
//        /// <returns></returns>
//        [HttpPut(nameof(UpdateSchedule))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
//        public async Task<HttpResponseMessage> UpdateSchedule(Schedule schedule)
//        {



//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }
//        /// <summary>
//        ///  Get all Schedules for an User
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <returns></returns>
//        [HttpGet(nameof(GetAllScheduleByUser))]
//        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
//        public async Task<HttpResponseMessage> GetAllScheduleByUser(int userId)
//        {



//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }
//    }
//}
