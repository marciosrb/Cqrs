using System.Collections.Generic;
using System.Text.Json.Serialization;
using CQRS.Application.DataTransferObject;

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