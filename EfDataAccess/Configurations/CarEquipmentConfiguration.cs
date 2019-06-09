using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    class CarEquipmentConfiguration : IEntityTypeConfiguration<CarEquipment>
    {
        public void Configure(EntityTypeBuilder<CarEquipment> builder)
        {
            builder.HasKey(ce => new { ce.CarId, ce.EquipmentId });
            builder.ToTable("CarEquipment");
        }


    }
}
