// using Microsoft.Extensions.Options;
// using MongoDB.Driver;
// using MongoTest2.Infrastructure;
// using MongoTest2.Data.Entities;

// namespace MongoTest2.Data
// {

//    public class IdentityContext
//    {
//         private readonly IMongoDatabase _database = null;

//         public IdentityContext(IOptions<Settings> settings)
//         {
//             //todo: refactor this
//             var client = new MongoClient(settings.Value.ConnectionString);
//             if (client != null)
//                 _database = client.GetDatabase(settings.Value.Database);
//         }



//             public IMongoCollection<Note> Notes
//         {
//             get
//             {
//                 return _database.GetCollection<Note>("Note");
//             }
//         }


//    }
// }