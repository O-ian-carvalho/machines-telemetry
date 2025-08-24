using MachinesTelemetry.Business.Models;

namespace MachinesTelemetry.Api.Dtos.Requests
{
    public class MachineCreateDto
    {
        public required string Name { get; set; }
        public required TelemetryCreateDto Telemetry { get; set; }

    }
}
