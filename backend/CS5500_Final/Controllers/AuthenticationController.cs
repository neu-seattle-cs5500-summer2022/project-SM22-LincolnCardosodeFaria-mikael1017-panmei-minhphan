using CS5500_Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CS5500_Final.Controllers
{
    [Produces("application/json")]
    public class AuthenticationController : Controller
        
    {
        /// <summary>
        ///  Request a user authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns if the authentication was a success or not.</returns>
        [HttpPost(nameof(Request))]
        public async Task<HttpResponseMessage> Login(Login user)
        {

            

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
