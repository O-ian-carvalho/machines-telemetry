using MachinesTelemetry.Business.Interfaces.Repositories;
using MachinesTelemetry.Business.Interfaces.Services;
using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Business.Services
{
    public class TelemetryService : BaseService<Telemetry>, ITelemetryService
    {
        private readonly ITelemetryRepository _telemetryRepository;
        public TelemetryService(ITelemetryRepository repository) : base(repository)
        {
            _telemetryRepository = repository;
        }

        public async Task<IEnumerable<Telemetry>> GetByMachineIdAsync(Guid machineId, int pageNumber, int pageSize)
        {
            return await _telemetryRepository.GetByMachineIdAsync(machineId, pageNumber, pageSize);
        }
    }
}
