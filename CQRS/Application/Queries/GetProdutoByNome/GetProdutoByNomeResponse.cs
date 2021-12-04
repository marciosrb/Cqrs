using System.Text.Json.Serialization;
using CQRS.Application.DataTransferObject;

namespace CQRS.Application.Queries
{
     public class GetProdutoByNomeResponse
    {
        [JsonPropertyNameAttribute("produto")]
        public ProdutoDto Produto { get; set; }

        [JsonPropertyNameAttribute("message")]
        public string Message { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int StatusCode { get; set; }
    }
}