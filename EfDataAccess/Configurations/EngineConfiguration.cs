using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired();
            builder.Property(e => e.CC)
                .IsRequired();
            builder.HasIndex(e => e.Name)
                .IsUnique();
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
