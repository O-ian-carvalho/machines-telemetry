using Microsoft.EntityFrameworkCore;
using MachinesTelemetry.Business.Models;
using System;

namespace MachinesTelemetry.Data
{
    public class MachinesTelemetryDbContext : DbContext
    {
        public MachinesTelemetryDbContext(DbContextOptions<MachinesTelemetryDbContext> options) : base(options) { }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Telemetry> Telemetries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MachinesTelemetryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
