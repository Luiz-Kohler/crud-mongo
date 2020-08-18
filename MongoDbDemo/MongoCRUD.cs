using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDbDemo
{
    public class MongoCRUD
    {
        private IMongoDatabase _db;

        public MongoCRUD(string database)
        {
            MongoClient client = new MongoClient();
            _db = client.GetDatabase(database);
        }

        public void Insert<T>(string table, T data)
        {
            IMongoCollection<T> collection = _db.GetCollection<T>(table);
            collection.InsertOne(data);
        }

        public List<T> GetAll<T>(string table)
        {
            IMongoCollection<T> collection = _db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T Get<T>(string table, Guid id)
        {
            IMongoCollection<T> collection = _db.GetCollection<T>(table);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).First();
        }

        public void Update<T>(string table, Guid id, T data)
        {
            IMongoCollection<T> collection = _db.GetCollection<T>(table);

            ReplaceOneResult result = collection.ReplaceOne(
                new BsonDocument("_id", id),
                data,
                new UpdateOptions { IsUpsert = true });

        }

        public void Delete<T>(string table, Guid id)
        {
            IMongoCollection<T> collection = _db.GetCollection<T>(table);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);

        }
    }
}
