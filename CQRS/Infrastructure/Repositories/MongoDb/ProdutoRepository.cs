using CQRS.Domain.DataAcess;
using CQRS.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Repositories.MongoDb
{
    public class ProdutoRepository : IProdutoRepository
    {
        private IProdutoReadRepository ProdutoReadRepository { get; }
        private IProdutoWriteRepository ProdutoWriteRepository { get; }

        public ProdutoRepository(
            IProdutoReadRepository produtoReadRepository,
            IProdutoWriteRepository produtoWriteRepository)
        {
            ProdutoReadRepository = produtoReadRepository;
            ProdutoWriteRepository = produtoWriteRepository;
        }

        public Produto FindProdutoByNome(string nome)
        {
            return ProdutoReadRepository.FindProdutoByNome(nome);
        }
/*
        public IList<Produto> FindProdutoByUser(string usuarioName)
        {
            return ProdutoReadRepository.FindProdutoByUser(usuarioName);
        }*/

        public async Task<Domain.Entity.Produto> Create(Domain.Entity.Produto produto)
        {
            return await ProdutoWriteRepository.Create(produto);
        }
    }
}