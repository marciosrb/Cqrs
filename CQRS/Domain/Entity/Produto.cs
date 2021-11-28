using CQRS.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CQRS.Domain.Entity
{
    public class Produto : Base
    {
        [ExcludeFromCodeCoverage]
        [BsonElement("Codigo")]
        public string Codigo { get; set; }

        [BsonElement("Usuario")]
        public string Usuario { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Valor")]
        public decimal Valor { get; set; }

        [JsonPropertyName("Estoque")]
        public List<Estoque> Estoque { get; set; }

    }
}
