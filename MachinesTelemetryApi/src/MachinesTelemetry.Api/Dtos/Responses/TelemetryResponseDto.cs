using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Api.Dtos.Responses
{
    public class TelemetryResponseDto
    {
        public  Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public required string Status { get; set; }
    }
}
