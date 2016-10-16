using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Multilanguage.Repository.MongoDb
{
    public class MongoRepository<TEntity> : AbstractMongoRepository<TEntity>, IMongoRepository<TEntity>
    {
        public MongoRepository(string connectionString, string database) : base(connectionString, database)
        {

        }
        public IQueryable<TEntity> Get()
        {
            return Collection.AsQueryable();
        }

        public ObjectId ParseParamId(string id)
        {
            return ObjectId.Parse(id);
        }
    }
}
