using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Business.Interfaces.Services
{
    public interface ITelemetryService : IBaseService<Telemetry>
    {
        Task<IEnumerable<Telemetry>> GetByMachineIdAsync(Guid machineId, int pageNumber, int pageSize);
    }
}
