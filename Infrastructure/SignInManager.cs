

using System.Threading.Tasks;
using MongoTest2.Data.Repositories;

namespace MongoTest2.Infrastructure
{

    public interface ISignInManager
    {
        Task<bool> SignInAsync(string userName, string password);
    }

    public class SignInManager : ISignInManager
    {

        private readonly IUserRepository _userRepository;

        public SignInManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<bool> SignInAsync(string userName, string password)
        {

            var user = await _userRepository.GetByName(userName);
            
            return user != null &&  user.PasswordHash == password ; 
        }
    }

}