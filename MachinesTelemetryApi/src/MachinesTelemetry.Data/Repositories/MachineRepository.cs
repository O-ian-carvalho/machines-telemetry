using MachinesTelemetry.Business.Interfaces.Repositories;
using MachinesTelemetry.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace MachinesTelemetry.Data.Repositories
{
    public class MachineRepository : Repository<Machine>, IMachineRepository
    {
        public MachineRepository(MachinesTelemetryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Machine>> GetAllWithTelemetriesAsync()
        {
            return await _dbSet.Include(m => m.Telemetries.OrderByDescending(p => p.CreatedAt).Take(1)).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Machine?> GetByIdWithTelemetriesAsync(Guid id)
        {
            return await _dbSet
                .Include(m => m.Telemetries.OrderByDescending(p => p.CreatedAt).Take(1))
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<IEnumerable<Machine>> GetByStatusWithTelemetriesAsync(EMachineStatus status)
        {
            return await _dbSet
                 .Include(m => m.Telemetries.OrderByDescending(p => p.CreatedAt).Take(1))
                  .Where(m => m.Telemetries
                    .OrderByDescending(t => t.CreatedAt)
                    .FirstOrDefault() != null &&
                    m.Telemetries.OrderByDescending(t => t.CreatedAt)
                    .First().Status == status)
                 .ToListAsync();              
        }


    }
}
