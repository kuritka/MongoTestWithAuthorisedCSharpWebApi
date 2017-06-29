using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoTest2.Infrastructure;
using MongoTest2.Model.Entities;

namespace MongoTest2.Model
{

   public class NoteContext
    {
        private readonly IMongoDatabase _database = null;

        public NoteContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Note> Notes
        {
            get
            {
                return _database.GetCollection<Note>("Note");
            }
        }
    }

}