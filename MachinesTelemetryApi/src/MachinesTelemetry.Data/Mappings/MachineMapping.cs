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
    public class MachineMapping : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.ToTable("Machines");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(m => m.Telemetries)
                   .WithOne(t => t.Machine)
                   .HasForeignKey(t => t.MachineId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(m => m.Name)
                    .IsUnique();
        }
    }
}
