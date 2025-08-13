using MongoDB.Bson;
using MongoDB.Driver;
using PTR.Mongo.WebApp.Data;
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.NoSQLRepositories.Interfaces;

namespace PTR.Mongo.WebApp.NoSQLRepositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IMongoCollection<Review> _collection;
        private const string IdField = "_id";

        public ReviewRepository(MongoDbContext context)
        {
            _collection = context.Reviews;
        }

        public async Task<IEnumerable<Review>> FindAsync(string fieldName, string fieldValue)
        {
            if (string.Equals(fieldName, "Id", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(fieldName, "_id", StringComparison.OrdinalIgnoreCase))
            {
                if (!ObjectId.TryParse(fieldValue, out var oid))
                    return Enumerable.Empty<Review>();

                var fId = Builders<Review>.Filter.Eq(r => r.Id, oid);
                return await _collection.Find(fId).ToListAsync();
            }

            var filter = Builders<Review>.Filter.Eq(fieldName, fieldValue);
            var cursor = await _collection.FindAsync(filter);
            return cursor.ToList();
        }

        public async Task<Review?> FindByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var oid))
                return null;

            var filter = Builders<Review>.Filter.Eq(r => r.Id, oid);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Review document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task<bool> UpdateAsync(Review document, string id)
        {
            if (!ObjectId.TryParse(id, out var oid))
                return false;

            var filter = Builders<Review>.Filter.Eq(r => r.Id, oid);

            var setDoc = document.ToBsonDocument();
            if (setDoc.Contains(IdField))
                setDoc.Remove(IdField);

            var update = new BsonDocument("$set", setDoc);
            var result = await _collection.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task DeleteAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var oid))
                return;

            var filter = Builders<Review>.Filter.Eq(r => r.Id, oid);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Review>> SearchByAuthorAsync(string partialName)
        {
            var regex = new BsonRegularExpression(partialName, "i");
            var filter = Builders<Review>.Filter.Regex(r => r.AuthorName, regex);

            var cursor = await _collection.FindAsync(filter);
            return cursor.ToList();
        }
    }
}