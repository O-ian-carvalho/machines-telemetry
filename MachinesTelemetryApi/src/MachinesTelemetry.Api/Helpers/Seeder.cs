using MachinesTelemetry.Business.Models;
using MachinesTelemetry.Data;
using Microsoft.EntityFrameworkCore;

namespace MachinesTelemetry.Api.Helpers
{
    public static class Seeder
    {
        public static async Task SeedAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MachinesTelemetryDbContext>();


            await context.Database.MigrateAsync();

            if (await context.Machines.AnyAsync()) return;

            var now = DateTime.UtcNow;

            var m1 = new Machine { Name = "Excavator A" };
            var m2 = new Machine { Name = "Bulldozer B" };
            var m3 = new Machine { Name = "Crane C" };

            m1.Telemetries = BuildTelemetries(m1, (-23.5505, -46.6333), now, count: 6).ToList();
            m2.Telemetries = BuildTelemetries(m2, (-22.9035, -43.2096), now.AddMinutes(-5), count: 5).ToList();
            m3.Telemetries = BuildTelemetries(m3, (-19.9167, -43.9345), now.AddMinutes(-10), count: 7).ToList();

            await context.Machines.AddRangeAsync(m1, m2, m3);
            await context.SaveChangesAsync();
        }

        
        private static IEnumerable<Telemetry> BuildTelemetries(
            Machine machine,
            (double lat, double lng) start,
            DateTime baseTime,
            int count = 5)
        {
            var rnd = new Random(machine.Name.GetHashCode());
            var lat = start.lat;
            var lng = start.lng;
            var statuses = new[] { EMachineStatus.Operating, EMachineStatus.Maintenance, EMachineStatus.Stopped };

            for (int i = count - 1; i >= 0; i--)
            {
                lat += (rnd.NextDouble() - 0.5) * 0.01;
                lng += (rnd.NextDouble() - 0.5) * 0.01;

                yield return new Telemetry
                {
                    MachineId = machine.Id,
                    Machine = machine,                    
                    Latitude = Math.Round(lat, 6),
                    Longitude = Math.Round(lng, 6),
                    Status = statuses[rnd.Next(statuses.Length)],
                    CreatedAt = baseTime.AddMinutes(-i * 15)  
                };
            }
        }
    }
}
