using CQRS.Domain.DataAcess;
using CQRS.Domain.Entity;
using System.Collections.Generic;

namespace CQRS.Infrastructure.Repositories.MongoDb
{
    public class ProdutoRepository : IProdutoRepository
    {
        private IProdutoReadRepository ProdutoReadRepository { get; }

        public ProdutoRepository(
            IProdutoReadRepository produtoReadRepository)
        {
            ProdutoReadRepository = produtoReadRepository;
        }

        public Produto FindProdutoById(string produtoId)
        {
            return ProdutoReadRepository.FindProdutoById(produtoId);
        }

        public List<Produto> FindProdutoByUser(string usuarioName)
        {
            return ProdutoReadRepository.FindProdutoByUser(usuarioName);
        }
    }
}