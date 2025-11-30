using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Api.Dtos.Responses
{
    public class MachineResponseDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public TelemetryResponseDto? LastTelemetry { get; set; }

    }
}
