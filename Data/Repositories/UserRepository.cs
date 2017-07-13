using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoTest2.Infrastructure;
using MongoTest2.Data.Entities;
using MongoTest2.Data;

namespace MongoTest2.Data.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context = null;

        public UserRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }


        public async Task AddUser(ApplicationUser item)
        {
            await _context.Users.InsertOneAsync(item);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            var filter = Builders<ApplicationUser>.Filter.Eq("Id", id);
            return await _context.Users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetByName(string userName)
        {
            var filter = Builders<ApplicationUser>.Filter.Eq("UserName", userName);
            return await _context.Users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveAllUsers()
        {
            return await _context.Users.DeleteManyAsync(new BsonDocument());
        }
    }

}