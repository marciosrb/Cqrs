using CQRS.CrossCutting.Commom;
using CQRS.Domain.Entity;
using CQRS.Domain.Enum;
using CQRS.Domain.ValueObjects;
using MongoDB.Bson;
//using Newtonsoft.Json;
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
        
        [JsonPropertyNameAttribute("ativo")]         
        public bool Ativo { get; set; }

        [JsonPropertyNameAttribute("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyNameAttribute("preço")]
        public decimal Preco { get; set; }    

        [JsonPropertyNameAttribute("grupo")]
        public string Grupo { get; set; }    

        [JsonPropertyNameAttribute("estoque")]
        public IList<Estoque> Estoque { get; set; }

        internal static Domain.Entity.Produto Build(ProdutoDto produto)
        {          
            var isAtivo = produto.Ativo;

            return new Domain.Entity.Produto
            {  
               Id = produto.Id,              
               NomeProduto = produto.NomeProduto,
               UsuarioCadastro = produto.UsuarioCadastro,
               isAtivo = Convert.ToInt32(isAtivo),
               Tipo = produto.Tipo,
               Preco = produto.Preco,
               Grupo = produto.Grupo,              
               Estoque = produto.Estoque.ToList()
            };
        }

        internal static ProdutoDto Build(Produto produto)
        {       
            var cidadeStatus = produto.isAtivo;

            return new ProdutoDto
            {                                         
               NomeProduto = produto.NomeProduto,
               UsuarioCadastro = produto.UsuarioCadastro,
               Ativo = Convert.ToBoolean(produto.isAtivo),
               Tipo = produto.Tipo,
               Preco = produto.Preco,
               Grupo = produto.Grupo,              
               Estoque = produto.Estoque.ToList()
            };           
        }
        
    }
}