using System.Text.Json.Serialization;
using CQRS.Application.Command.DeleteProduto;
using MediatR;

namespace Templates.Application.Command.DeleteProduto
{
    public class DeleteProdutoRequest: IRequest<DeleteProdutoResponse>
    {  
        [JsonPropertyNameAttribute("produtoId")]        
        public string ProdutoId { get; set; }
    }
}