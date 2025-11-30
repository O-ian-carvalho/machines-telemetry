using MachinesTelemetry.Business.Models;
using Microsoft.AspNetCore.Http;

namespace MachinesTelemetry.Business.Interfaces.Services
{
    public interface IMachineService : IBaseService<Machine>
    {
        Task<IEnumerable<Machine>> GetAllWithTelemetriesAsync();
        Task<Machine?> GetByIdWithTelemetriesAsync(Guid id);
        Task<IEnumerable<Machine>> GetByStatusWithTelemetriesAsync(EMachineStatus status);
        Task<Machine> UploadImageAsync(Guid id, IFormFile file);
    }
}