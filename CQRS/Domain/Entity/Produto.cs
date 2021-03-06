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
        public int isAtivo { get; set; }
        public string Tipo { get; set; }
        public string Grupo { get; set; }
        public decimal Preco { get; set; }
        public List<Estoque> Estoque { get; set; }

    }
}
