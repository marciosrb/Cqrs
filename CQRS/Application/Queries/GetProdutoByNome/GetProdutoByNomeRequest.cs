using MediatR;

namespace CQRS.Application.Queries
{
    public class GetProdutoByNomeRequest : IRequest<GetProdutoByNomeResponse>
    {
        public string Nome { get; set; }
    }
}