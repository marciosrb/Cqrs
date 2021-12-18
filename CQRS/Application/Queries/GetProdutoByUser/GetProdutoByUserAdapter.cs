using System.Net.Http.Headers;
using CQRS.Application.DataTransferObject;
using CQRS.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Application.Queries.GetProdutoByUser
{
    public class GetProdutoByUserAdapter
    {
        public IList<GrupoDto> Adapt(IList<Produto> produto)
        {
            var grupoProduto = produto
            
            .GroupBy(x => new {x.Grupo})
            .Select(group => new GrupoDto {Key = new KeyGrupoDto{Grupo = group.Key.Grupo}, Produtos = group
            .Select(x => ProdutoDto.Build(x)).ToList()});

            return grupoProduto.ToList();
    }
}
}