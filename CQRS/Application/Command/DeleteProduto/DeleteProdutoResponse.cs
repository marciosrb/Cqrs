using System.Text.Json.Serialization;

namespace CQRS.Application.Command.DeleteProduto
{
    public class DeleteProdutoResponse
    {
        [JsonPropertyNameAttribute("message")] 
        public string Message { get; set; }
        
        [JsonPropertyNameAttribute("statusCode")] 
        public int StatusCode { get; set; }
    }
}