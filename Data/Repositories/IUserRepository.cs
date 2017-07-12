using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoTest2.Data;
using MongoTest2.Data.Entities;

namespace MongoTest2.Data.Repositories
{
    public interface IUserRepository
    {
           Task<IEnumerable<ApplicationUser>> GetAllUsers();
           Task<ApplicationUser> GetUser(string id);

           Task<ApplicationUser> GetByName(string userName);


           Task AddUser(ApplicationUser item);

           Task<DeleteResult> RemoveAllUsers();
    }
}