using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Api.Dtos.Requests
{
    public class TelemetryCreateDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public required string Status { get; set; }
    }
}
