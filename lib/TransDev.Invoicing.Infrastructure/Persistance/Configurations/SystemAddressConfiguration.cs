namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class SystemAddressConfiguration : IEntityTypeConfiguration<SystemAddress>
{
    public void Configure(EntityTypeBuilder<SystemAddress> builder)
    {
        builder
            .ToTable("SystemAddress");

        builder
            .HasKey(address => address.Id);

        builder
            .HasOne(address => address.State)
            .WithMany()
            .HasForeignKey(address => address.SystemStateId);

        builder
            .Property(address => address.Address)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(address => address.ZipCode)
            .IsRequired()
            .HasMaxLength(10);

    }
}
