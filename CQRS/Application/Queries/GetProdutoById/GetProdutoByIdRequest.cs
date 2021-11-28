using MediatR;

namespace CQRS.Application.Queries
{
    public class GetProdutoByIdRequest : IRequest<GetProdutoByIdResponse>
    {
        public string ProdutoId { get; set; }
    }
}