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

            var machines = new List<Machine>
            {
                new Machine { Name = "Escavadeira Hidráulica" },
                new Machine { Name = "Trator de Esteira" },
                new Machine { Name = "Guindaste Móvel" },
                new Machine { Name = "Carregadeira de Rodas" },
                new Machine { Name = "Motoniveladora" },
                new Machine { Name = "Empilhadeira" },
                new Machine { Name = "Betoneira" },
                new Machine { Name = "Caminhão Caçamba" },
                new Machine { Name = "Mini Escavadeira" },
                new Machine { Name = "Retroescavadeira" }
            };

            var coordinates = new (double lat, double lng)[]
            {
                (-23.5505, -46.6333), 
                (-22.9035, -43.2096), 
                (-19.9167, -43.9345), 
                (-15.7942, -47.8822), 
                (-12.9714, -38.5014),
                (-3.7172, -38.5431), 
                (-30.0346, -51.2177), 
                (-25.4284, -49.2733), 
                (-8.0476, -34.8770),  
                (-20.3197, -40.3373) 
            };

            for (int i = 0; i < machines.Count; i++)
            {
                machines[i].Telemetries = BuildTelemetries(
                    machines[i],
                    coordinates[i],
                    now.AddMinutes(-i * 10),
                    count: 10 
                ).ToList();
            }

            await context.Machines.AddRangeAsync(machines);
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
