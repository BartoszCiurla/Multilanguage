using System.Linq;
using MongoDB.Bson;

namespace Multilanguage.Repository.MongoDb
{
    public interface IMongoRepository<TEntity>
    {
        IQueryable<TEntity> Get();
        ObjectId ParseParamId(string id);
    }
}
