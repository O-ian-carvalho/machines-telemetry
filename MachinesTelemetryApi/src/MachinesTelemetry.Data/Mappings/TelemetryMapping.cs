using MachinesTelemetry.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTelemetry.Data.Mappings
{
    public class TelemetryMapping : IEntityTypeConfiguration<Telemetry>
    {


        public void Configure(EntityTypeBuilder<Telemetry> builder)
        {

            builder.ToTable("Telemetries");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Latitude)
                .IsRequired();

            builder.Property(m => m.Longitude)
                .IsRequired();

            builder.HasOne(t => t.Machine)
                  .WithMany(m => m.Telemetries)
                  .HasForeignKey(t => t.MachineId)
                  .OnDelete(DeleteBehavior.Cascade); 


        }
    }
}
