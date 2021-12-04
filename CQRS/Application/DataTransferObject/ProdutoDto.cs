using CQRS.Domain.Entity;
using CQRS.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CQRS.Application.DataTransferObject
{
    public class ProdutoDto
    {
        [JsonIgnore]
        [JsonPropertyNameAttribute("id")]
        public string Id { get; set; }       

        [JsonPropertyNameAttribute("nome")]
        public string Nome { get; set; }

        [JsonPropertyNameAttribute("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyNameAttribute("preço")]
        public decimal Preco { get; set; }        

        [JsonPropertyNameAttribute("estoque")]
        public IList<Estoque> Estoque { get; set; }

        internal static Domain.Entity.Produto Build(ProdutoDto produto)
        {
            return new Domain.Entity.Produto
            {
               Id = produto.Id,              
               Nome = produto.Nome,
               Tipo = produto.Tipo,
               Preco = produto.Preco,               
               Estoque = produto.Estoque.ToList()
            };
        }

        internal static ProdutoDto Build(Produto produto)
        {
            return new ProdutoDto
            {                          
               Nome = produto.Nome,
               Tipo = produto.Tipo,
               Preco = produto.Preco,               
               Estoque = produto.Estoque.ToList()
            };
        }
    }
}