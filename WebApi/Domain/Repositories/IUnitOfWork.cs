using System.Threading.Tasks;

namespace WebApi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
