using CQRS.Domain.Entity;
using System.Collections.Generic;

namespace CQRS.Domain.DataAcess
{
    public interface IProdutoReadRepository
    {
        Produto FindProdutoById(string produtoId);
        public List<Produto> FindProdutoByUser(string usuarioName);
    }
}