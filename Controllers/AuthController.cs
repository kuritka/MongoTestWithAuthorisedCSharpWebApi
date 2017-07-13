using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using MongoTest2.Data.Entities;
using MongoTest2.Data.Repositories;
using MongoTest2.Infrastructure;
using MongoTest2.Infrastructure.Crypto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.MongoDB;
using Microsoft.AspNetCore.Authorization;

namespace MongoTest2.Controllers
{

    public class AuthController : Controller 
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IUserRepository _userRepository;

        public AuthController(
            IUserRepository userRepository
            , Microsoft.AspNetCore.Identity.SignInManager<ApplicationUser> signInManager
            )
        {
            _signInManager = signInManager;
            _userRepository = userRepository;
        }



        [HttpPost("api/auth/login")]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            if(TryValidateModel(credentials))
            {
                try
                {

                    var user = await  _userRepository.GetByName(credentials.UserName);

                    if(user != null)
                    {
                        await _signInManager.SignInAsync(user, false);

                        return Ok("User Authenticated");
                    }
                }
                catch(Exception ex){
                    System.Console.WriteLine("Exception occured: " + ex.Message);
                }
            }
            return BadRequest("Failed Login");
        }




        [HttpGet("api/auth/logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok("Signed out");
        }

    } 
}

