using MachinesTelemetry.Business.Interfaces.Repositories;
using MachinesTelemetry.Business.Interfaces.Services;
using MachinesTelemetry.Business.Models;


namespace MachinesTelemetry.Business.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;
        public BaseService(IRepository<T>  repository)
        {
            _repository = repository;
        }

        public virtual async Task AddAsync(T entity)
        {
             await _repository.AddAsync(entity);
              await _repository.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task UpdateAsync(T entity, Guid id)
        {
            if(await GetByIdAsync(id) == null) throw new KeyNotFoundException("IdNotFound");
            
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
