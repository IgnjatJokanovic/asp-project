using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.Username)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.RoleId).HasDefaultValue(1);
        }
    }
}
