using MachinesTelemetry.Business.Interfaces.Repositories;
using MachinesTelemetry.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace MachinesTelemetry.Data.Repositories
{
    public class TelemetryRepository : Repository<Telemetry>, ITelemetryRepository
    {
        public TelemetryRepository(MachinesTelemetryDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Telemetry>> GetByMachineIdAsync(Guid machineId, int pageNumber, int pageSize)
        {
            return await _dbSet
                .Where(t => t.MachineId == machineId)
                .OrderByDescending(t => t.CreatedAt)
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize) 
                .ToListAsync(); 
        }

    }

}
