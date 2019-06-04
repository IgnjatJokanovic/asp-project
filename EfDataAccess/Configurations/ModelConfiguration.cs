using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired();
            builder.Property(m => m.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.HasIndex(m => m.Name)
                .IsUnique();
        }
    }
}
