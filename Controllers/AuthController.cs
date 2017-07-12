using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using MongoTest2.Data.Entities;
using MongoTest2.Data.Repositories;
using MongoTest2.Infrastructure;

namespace MongoTest2.Controllers
{

    public class AuthController : Controller 
    {
        private readonly ISignInManager _signInManager;

        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository, ISignInManager signInManager)
        {
            _signInManager = signInManager;
            _userRepository = userRepository;
        }



        private async Task<bool> SignInAsync(string userName)
        {
            var user = await _userRepository.GetUser(userName);
            return user != null; 
        }


        [HttpPost("api/auth/login")]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            if(TryValidateModel(credentials))
            {
                try
                {
                    var result = await _signInManager.SignInAsync(credentials.UserName, credentials.Password);

                    //var result = await _signInManager.PasswordSignInAsync(credentials.UserName, credentials.Password, false,false);
                    if(result)
                    {
                        return Ok();
                    }
                }
                catch(Exception ex){
                    System.Console.WriteLine("Exception occured: " + ex.Message);
                }
            }
            return BadRequest("Failed Login");
        }
    } 
}

