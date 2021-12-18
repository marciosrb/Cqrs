using CQRS.Domain.DataAcess;
using CQRS.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Repositories.MongoDb
{
    public class GrupoRepository : IGrupoRepository
    {
        private IGrupoReadRepository GrupoReadRepository { get; }      

        public GrupoRepository(
            IGrupoReadRepository grupoReadRepository)
        {
            GrupoReadRepository = grupoReadRepository;           
        }

        public ProdutoGrupo FindNomeGrupoById(string id)
        {
             return GrupoReadRepository.FindNomeGrupoById(id);           
        }
    }
}