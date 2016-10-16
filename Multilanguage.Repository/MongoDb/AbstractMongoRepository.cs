using MongoDB.Driver;

namespace Multilanguage.Repository.MongoDb
{
    public abstract class AbstractMongoRepository<TEntity>
    {
        protected IMongoCollection<TEntity> Collection;
        private IMongoDatabase _database;

        protected AbstractMongoRepository(string connectionString, string database)
        {
            //"mongodb://localhost:27017", "PizaaStore"
            GetDatabase(connectionString, database);
            GetCollection();
        }

        private void GetDatabase(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        private void GetCollection()
        {
            Collection = _database
                .GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
        }
    }
}
