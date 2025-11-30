using Microsoft.AspNetCore.Http;

namespace MachinesTelemetry.Business.Interfaces.Services
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
