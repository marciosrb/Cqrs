using CQRS.Domain.Enum;
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
        public string NomeProduto { get; set; }
        public string UsuarioCadastro { get; set; }
        public Cidade Cidade { get; set; }
        public string Tipo { get; set; }
        public decimal Preco { get; set; }
        public IList<Estoque> Estoque { get; set; }

    }
}
