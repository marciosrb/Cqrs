using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CQRS.Domain.Entity
{
    public class Cidade
    {
        [BsonElement("Cidade")]
        public int cidade { get; set; }
    }
}