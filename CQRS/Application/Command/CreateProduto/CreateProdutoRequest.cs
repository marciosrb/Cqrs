using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CQRS.Application.DataTransferObject;
using MediatR;

namespace CQRS.Application.Command.CreateProduto
{
    public class CreateProdutoRequest : IRequest<CreateProdutoResponse>
    {
        [Required(ErrorMessage = "The {0} cannot be null.")]
        [JsonPropertyNameAttribute("produto")]
        public ProdutoDto Produto { get; set; }
    }
}