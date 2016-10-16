using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Multilanguage.Model.Pizza
{
    public class Pizza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<PizzaContent> Contents { get; set; }
    }
}
