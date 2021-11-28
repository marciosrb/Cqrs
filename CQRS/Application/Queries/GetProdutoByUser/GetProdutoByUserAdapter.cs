using CQRS.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Application.Queries.GetProdutoByUser
{
    public class GetProdutoByUserAdapter
    {
        public List<ProdutoDto> Adapt(List<Produto> produto)
        {
            //return ProdutoDto.Build(produto);
            return produto.Select(x =>  ProdutoDto.Build(x)).ToList();
        }
    }
}