using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoTest2.Infrastructure;
using MongoTest2.Data.Entities;
using MongoTest2.Data.Repositories;


namespace MongoTest2.Data.Seeding
{
    public class IdentitySeed
    {

        private readonly IUserRepository _userRepository;

        public IdentitySeed(IUserRepository userRepository)
        {
            if(userRepository == null) throw new ArgumentNullException($"{userRepository}");
            _userRepository = userRepository;
        }


        public void Seed(bool reset)
        {
            if (reset)
            {
                _userRepository.RemoveAllUsers();

                _userRepository.AddUser(new ApplicationUser(){UserName ="MichalK", PasswordHash="password"});

                _userRepository.AddUser(new ApplicationUser(){UserName ="JardaN", PasswordHash="password2"});
            }
        }

    }
}