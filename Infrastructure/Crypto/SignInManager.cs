using System;
using System.Threading.Tasks;
using MongoTest2.Data.Repositories;

namespace MongoTest2.Infrastructure.Crypto
{

    public class SignInManager : ISignInManager
    {
        private readonly IUserRepository _userRepository;

        private readonly ICryptoStrategy _cryptoStrategy;

        public SignInManager(IUserRepository userRepository, ICryptoStrategy cryptoStrategy)
        {
            if(userRepository == null) throw new ArgumentNullException($"{userRepository}");
            if(cryptoStrategy == null) throw new ArgumentNullException($"{cryptoStrategy}");
            _userRepository = userRepository;
            _cryptoStrategy = cryptoStrategy;
        }


        public async Task<bool> SignInAsync(string userName, string password)
        {
            var user = await _userRepository.GetByName(userName);

            return user != null &&  user.PasswordHash == _cryptoStrategy.Encrypt(password) ; 
        }
    }

}