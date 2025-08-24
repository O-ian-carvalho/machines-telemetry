namespace MachinesTelemetry.Business.Models
{
    public class Telemetry : BaseEntity
    {
        public required Guid MachineId { get; set; }
        public Machine? Machine { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public EMachineStatus Status { get; set; }
    }
}
