using CQRS.CrossCutting;
using CQRS.Domain.DataAcess;
using CQRS.Domain.Entity;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Infrastructure.Repositories.MongoDb
{
    public class ProdutoReadRepository : IProdutoReadRepository
    {
        private readonly IMongoCollection<Produto> _produto;

        public ProdutoReadRepository(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produto = database.GetCollection<Produto>(settings.CollectionName);
        }

       /* public List<Produto> FindProdutoByNome() =>
            _produto.Find(book => true).ToList();*/

        public Produto FindProdutoByNome(string nome) =>
            _produto.Find<Produto>(x => x.Nome == nome).FirstOrDefault();

      /*  public IList<Produto> FindProdutoByUser(string usuarioName) =>
            _produto.Find(x => x.Usuario == usuarioName.ToLower()).ToList();*/
    }
}