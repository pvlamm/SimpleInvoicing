namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class SystemStateConfiguration : IEntityTypeConfiguration<SystemState>
{
    public void Configure(EntityTypeBuilder<SystemState> builder)
    {
        builder
            .ToTable("SystemState");

        builder
            .HasKey(state => state.Id);

        builder
            .HasMany(state => state.Cities)
            .WithOne(city => city.State)
            .HasForeignKey(city => city.SystemStateId);

        builder
            .Property(state => state.Id)
            .IsRequired(true)
            .HasMaxLength(2);

        builder
            .Property(state => state.Name)
            .IsRequired()
            .HasMaxLength(26);
    }
}
