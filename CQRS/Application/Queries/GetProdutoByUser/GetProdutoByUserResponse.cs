using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CQRS.Application.Queries.GetProdutoByUser
{
    public class GetProdutoByUserResponse
    {
        [JsonPropertyNameAttribute("produto")]
        public IList<ProdutoDto> Produto { get; set; }

        [JsonPropertyNameAttribute("message")]
        public string Message { get; set; }

        [JsonPropertyNameAttribute("statusCode")]
        public int StatusCode { get; set; }
    }
}