using MachinesTelemetry.Business.Models;
using System.Linq.Expressions;

namespace MachinesTelemetry.Business.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveChangesAsync();
        Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate);

    }

}
