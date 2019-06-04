using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired();
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.HasMany(e => e.CarEquipment)
                .WithOne(ce => ce.Equipment)
                .HasForeignKey(ce => ce.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
