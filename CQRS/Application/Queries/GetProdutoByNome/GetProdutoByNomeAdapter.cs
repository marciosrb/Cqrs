using CQRS.Application.DataTransferObject;

namespace CQRS.Application.Queries
{
    public class GetProdutoByNomeAdapter
    {
        public ProdutoDto Adapt(Domain.Entity.Produto produto)
        {
            return ProdutoDto.Build(produto);
        }
    }
}