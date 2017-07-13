using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using MongoTest2.Data;
using MongoTest2.Data.Entities;

namespace MongoTest2.Infrastructure
{
    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {

        private readonly DatabaseContext _context;

        //public class CustomUserStore : UserStore<ApplicationUser, ApplicationRole, MyContext, Guid>
        //{

        public CustomUserStore(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
                var filter = Builders<ApplicationUser>.Filter.Eq("Id", userId);
                return await _context.Users
                                    .Find(filter)
                                    .FirstOrDefaultAsync();
            
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
                //PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
                //var passwordHashed = hasher.HashPassword(new ApplicationUser() { UserName = "admin" }, "password");
                var filter = Builders<ApplicationUser>.Filter.Eq("UserName", normalizedUserName);
                return  await _context.Users.Find(filter).FirstOrDefaultAsync();
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.PasswordHash;
            });
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.Id;
            });
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return user.UserName;
            });
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}