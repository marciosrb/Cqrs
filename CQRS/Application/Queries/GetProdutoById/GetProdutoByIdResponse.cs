using System.Text.Json.Serialization;

namespace CQRS.Application.Queries
{
    public class GetProdutoByIdResponse
    {
        [JsonPropertyNameAttribute("produto")]
        public ProdutoDto Produto { get; set; }

        [JsonPropertyNameAttribute("message")]
        public string Message { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int StatusCode { get; set; }
    }
}