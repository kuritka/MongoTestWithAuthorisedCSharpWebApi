using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoTest2.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public override string UserName
        {
            get
            {
                return base.UserName;
            }

            set
            {
                base.UserName = value;
                base.NormalizedUserName = value.ToUpper();
            }
        }

        string _password;
        public string Password
        {
            set
            {
                PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
                this.PasswordHash = hasher.HashPassword(this, value);
                _password = value;
            }
            get
            {
                return _password;
            }
        }

    }
}



