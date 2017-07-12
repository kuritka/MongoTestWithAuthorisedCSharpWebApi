using System.Threading.Tasks;

namespace MongoTest2.Infrastructure.Crypto
{

    public interface ISignInManager
    {
        Task<bool> SignInAsync(string userName, string password);
    }

}