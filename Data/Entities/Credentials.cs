using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoTest2.Data.Entities
{
    public class Credentials
    {
        [Required]        
        public string UserName {get; set;}
        
        [Required]
        public string Password {get; set;}

    }
}