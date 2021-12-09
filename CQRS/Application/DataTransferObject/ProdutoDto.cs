using CQRS.Domain.Entity;
using CQRS.Domain.Enum;
using CQRS.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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

        [JsonPropertyNameAttribute("nomeProduto")]
        public string NomeProduto { get; set; }
        
        [JsonPropertyNameAttribute("usuarioCadastro")]
        public string UsuarioCadastro { get; set; }      
        
        [BsonRepresentation(BsonType.String)]         
        public Cidade Cidade { get; set; }

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
               NomeProduto = produto.NomeProduto,
               UsuarioCadastro = produto.UsuarioCadastro,
               Cidade = produto.Cidade,
               Tipo = produto.Tipo,
               Preco = produto.Preco,               
               Estoque = produto.Estoque.ToList()
            };
        }

        internal static ProdutoDto Build(Produto produto)
        {
            return new ProdutoDto
            {                                         
               NomeProduto = produto.NomeProduto,
               UsuarioCadastro = produto.UsuarioCadastro,
               Cidade = produto.Cidade,
               Tipo = produto.Tipo,
               Preco = produto.Preco,               
               Estoque = produto.Estoque.ToList()
            };
            
        }
    }
}