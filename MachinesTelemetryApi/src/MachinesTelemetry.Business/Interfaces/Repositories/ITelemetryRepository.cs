using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Business.Interfaces.Repositories
{
    public interface ITelemetryRepository : IRepository<Telemetry>
    {
        Task<IEnumerable<Telemetry>> GetByMachineIdAsync(Guid machineId, int pageNumber, int pageSize);
    }
}
