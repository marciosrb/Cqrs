using MediatR;

namespace CQRS.Application.Queries.GetProdutoByUser
{
    public class GetProdutoByUserRequest : IRequest<GetProdutoByUserResponse>
    {
        public string UserName { get; set; }
    }
}