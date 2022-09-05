namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class SystemCityConfiguration : IEntityTypeConfiguration<SystemCity>
{
    public void Configure(EntityTypeBuilder<SystemCity> builder)
    {
        builder
            .ToTable("SystemCity");

        builder
            .HasKey(city => city.Id);

        builder
            .HasOne(city => city.State)
            .WithMany(state => state.Cities)
            .HasForeignKey(city => city.SystemStateId);

        // 85 characters long, in case we ever decide to cover New Zealand
        builder
            .Property(city => city.Name)
            .HasMaxLength(85)
            .IsRequired();
    }
}
