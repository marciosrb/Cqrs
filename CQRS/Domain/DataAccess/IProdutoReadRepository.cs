using CQRS.Domain.Entity;
using System.Collections.Generic;

namespace CQRS.Domain.DataAcess
{
    public interface IProdutoReadRepository
    {
          Produto FindProdutoByNome(string nome);
          Produto FindProdutoById(string id);          
          public List<Produto> FindProdutoByUser(string usuarioName);
    }
}