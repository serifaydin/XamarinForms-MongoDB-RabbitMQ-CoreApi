using MongoDB.Driver;
using System;

namespace MLTP.Infrastructure.MongoDB
{
    public class MongoDBService : IMongoDBService
    {
        private MongoClient mongoClient;
        private IMongoCollection<AppModel> mongoCollection;

        public MongoDBService()
        {
            mongoClient = new MongoClient(MongoDbModel.UrlIp);
            var database = mongoClient.GetDatabase(MongoDbModel.DatabaseName);
            mongoCollection = database.GetCollection<AppModel>(MongoDbModel.CollectionName);
        }

        public void Create(AppModel model)
        {
            mongoCollection.InsertOne(model);
        }
    }
}