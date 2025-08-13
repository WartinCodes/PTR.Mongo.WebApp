using MongoDB.Bson;
using MongoDB.Driver;

namespace PTR.Mongo.WebApp.Data
{
    public class MongoDbInitializer
    {
        private readonly MongoDbContext _context;

        public MongoDbInitializer(MongoDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            var collections = _context.Database.ListCollectionNames().ToList();
            if (!collections.Contains("Reviews"))
            {
                _context.Database.CreateCollection("Reviews");
            }

            //var reviewsRaw = _context.Database.GetCollection<BsonDocument>("Reviews");

            //var filterNeedsRename = Builders<BsonDocument>.Filter.And(
            //    Builders<BsonDocument>.Filter.Exists("comment", true),
            //    Builders<BsonDocument>.Filter.Not(Builders<BsonDocument>.Filter.Exists("comentario", true))
            //);

            //var rename = Builders<BsonDocument>.Update.Rename("comment", "comentario");

            //var result = reviewsRaw.UpdateMany(filterNeedsRename, rename);
        }
    }
}