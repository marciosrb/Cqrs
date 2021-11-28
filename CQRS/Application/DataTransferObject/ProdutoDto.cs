using CQRS.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CQRS.Application
{
    public class ProdutoDto
    {
        [JsonPropertyNameAttribute("id")]
        public string Id { get; set; }

        [JsonPropertyNameAttribute("Codigo")]
        public string Codigo { get; set; }

        [JsonPropertyNameAttribute("Usuario")]
        public string Usuario { get; set; }

        [JsonPropertyNameAttribute("Name")]
        public string Name { get; set; }

        [JsonPropertyNameAttribute("Price")]
        public decimal Valor { get; set; }        

        [JsonPropertyNameAttribute("Estoque")]
        public List<Estoque> Estoque { get; set; }

        public static ProdutoDto Build(Domain.Entity.Produto produto)
        {
            return new ProdutoDto
            {
               Id = produto.Id,
               Codigo = produto.Codigo,
               Usuario = produto.Usuario,
               Name = produto.Nome,
               Valor = produto.Valor,               
               Estoque = produto.Estoque.ToList()
            };
        }
    }
}