using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Business.Interfaces.Services
{
    public interface IMachineService : IBaseService<Machine>
    {
        Task<IEnumerable<Machine>> GetAllWithTelemetriesAsync();
        Task<Machine?> GetByIdWithTelemetriesAsync(Guid id);
        Task<IEnumerable<Machine>> GetByStatusWithTelemetriesAsync(EMachineStatus status);
    }
}
