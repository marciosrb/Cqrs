using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace CQRS.Domain.ValueObjects
{
    public class Estoque
    {

        [ExcludeFromCodeCoverage]
        [BsonElement("Corredor")]
        public string Corredor { get; set; }

        [BsonElement("Repositor")]
        public string Repositor { get; set; }
    }
}