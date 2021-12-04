using System;
using System.Threading.Tasks;
using CQRS.CrossCutting;
using CQRS.Domain.DataAcess;
using CQRS.Domain.Entity;
using MongoDB.Driver;

namespace CQRS.Infrastructure.Repositories.MongoDb
{
    public class ProdutoWriteRepository : IProdutoWriteRepository
    {
       private IMongoCollection<Produto> _produto;

        public ProdutoWriteRepository(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produto = database.GetCollection<Produto>(settings.CollectionName);
        } 

        #region ITemplateWriteRepository implementation

        public async Task<Domain.Entity.Produto> Create(Domain.Entity.Produto produto)
        {   
            await _produto.InsertOneAsync(produto);
            
            return produto;
        }
        #endregion
    }
}
