using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.Price)
                .IsRequired();
            builder.Property(c => c.Src)
                .IsRequired();
            builder.Property(c => c.Alt)
                .IsRequired();
            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(c => c.CarEquipment)
                .WithOne(ce => ce.Car)
                .HasForeignKey(ce => ce.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
