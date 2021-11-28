namespace CQRS.Application.Queries
{
    public class GetProdutoByUserAdapter
    {
        public ProdutoDto Adapt(Domain.Entity.Produto produto)
        {
            return ProdutoDto.Build(produto);
        }
    }
}