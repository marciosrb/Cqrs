using System.Text.Json.Serialization;

namespace CQRS.Application.Command.CreateProduto
{
    public class CreateProdutoResponse
    {
        [JsonPropertyNameAttribute("message")]
        public string Message { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyNameAttribute("produtoId")]
        public string ProdutoId { get; set; }
    }
}