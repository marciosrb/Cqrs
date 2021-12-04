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
        [JsonPropertyNameAttribute("Nome")]
        public string Nome { get; set; }

        [JsonPropertyNameAttribute("Tipo")]
        public string Tipo { get; set; }

        [JsonPropertyNameAttribute("Preço")]
        public decimal Preco { get; set; }        

        [JsonPropertyNameAttribute("Estoque")]
        public IList<Estoque> Estoque { get; set; }

    }
}
