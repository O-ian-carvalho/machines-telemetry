using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Business.Interfaces.Repositories
{
    public interface IMachineRepository : IRepository<Machine>
    {
       Task<IEnumerable<Machine>> GetAllWithTelemetriesAsync();
       Task<Machine?> GetByIdWithTelemetriesAsync(Guid id);
       Task<IEnumerable<Machine>> GetByStatusWithTelemetriesAsync(EMachineStatus status);
    }
}
