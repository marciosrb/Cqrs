using System.Threading.Tasks;

namespace CQRS.Domain.DataAcess
{
    public interface IProdutoWriteRepository
    {
        Task<Entity.Produto> Create(Entity.Produto produto);
    }
}