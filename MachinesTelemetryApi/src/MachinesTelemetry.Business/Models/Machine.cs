namespace MachinesTelemetry.Business.Models
{
    public class Machine : BaseEntity
    {
        public required string Name { get; set; } = null!;
        public virtual ICollection<Telemetry> Telemetries { get; set; } = new List<Telemetry>();
        public Telemetry? LastTelemetry() => Telemetries.OrderByDescending(t => t.CreatedAt).FirstOrDefault();

    }
}
