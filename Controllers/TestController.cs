using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MongoTest2.Controllers
{
    [Authorize]
    //[Route("api/[controller]")]
    public class TestController : Controller
    {
        
        [HttpGet("api/test/AuthenticationAccess")]
        public IActionResult AuthenticationAccessTest()
        {
            return Ok("Access to authorised Section");
        }


        [AllowAnonymous]
        [HttpGet("api/test/AnonymousAccess")]
        public IActionResult AnonymousAccessTest()
        {
            return Ok("Access is always allowed");
        }


    }
}