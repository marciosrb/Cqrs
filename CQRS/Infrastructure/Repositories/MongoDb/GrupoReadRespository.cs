using CQRS.CrossCutting;
using CQRS.Domain.DataAcess;
using CQRS.Domain.Entity;
using MongoDB.Driver;
using System.Linq;

namespace CQRS.Infrastructure.Repositories.MongoDb
{
    public class GrupoReadRepository : IGrupoReadRepository
    {
        private readonly IMongoCollection<ProdutoGrupo> _nomeGrupo;

        public GrupoReadRepository(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
           
            _nomeGrupo = database.GetCollection<ProdutoGrupo>(settings.CollectionProdutoGrupo);
        } 
        public ProdutoGrupo FindNomeGrupoById(string id) =>
        _nomeGrupo.Find(x => x.Id == id).FirstOrDefault();
    }
}