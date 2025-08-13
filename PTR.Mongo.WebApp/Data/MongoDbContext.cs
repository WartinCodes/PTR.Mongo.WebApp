using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Security;

namespace PTR.Mongo.WebApp.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbConfiguration> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.Database);
        }

        public IMongoDatabase Database => _database;
        public IMongoCollection<Review> Reviews => _database.GetCollection<Review>("Reviews");
    }
}
