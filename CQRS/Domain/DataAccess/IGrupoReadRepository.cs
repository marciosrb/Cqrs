using CQRS.Domain.Entity;
using System.Collections.Generic;

namespace CQRS.Domain.DataAcess
{
    public interface IGrupoReadRepository
    {
       ProdutoGrupo FindNomeGrupoById(string id);         
    }
}