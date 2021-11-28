using CQRS.Domain.Entity;
using System.Collections.Generic;

namespace CQRS.Domain.DataAcess
{
    public interface IProdutoReadRepository
    {
        Produto FindProdutoById(string produtoId);
        public IList<Produto> FindProdutoByUser(string usuarioName);
    }
}