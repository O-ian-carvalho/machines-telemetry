using MachinesTelemetry.Business.Interfaces.Repositories;
using MachinesTelemetry.Business.Interfaces.Services;
using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Business.Services
{
    public class MachineService : BaseService<Machine>, IMachineService
    {
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository repository) : base(repository)
        {
            _machineRepository = repository;
        }

        public override async Task AddAsync(Machine entity)
        {
            var machine = await _repository.SearchAsync(m => m.Name == entity.Name);
            if (machine.Any()) throw new InvalidOperationException("MachineNameDuplicated");
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Machine>> GetAllWithTelemetriesAsync()
        {
            return await _machineRepository.GetAllWithTelemetriesAsync();
        }
      


        public async Task<Machine?> GetByIdWithTelemetriesAsync(Guid id)
        {
            return await _machineRepository.GetByIdWithTelemetriesAsync(id);
        }

        public async Task<IEnumerable<Machine>> GetByStatusWithTelemetriesAsync(EMachineStatus status)
        {
            return await _machineRepository.GetByStatusWithTelemetriesAsync(status);
        }
    }
}
