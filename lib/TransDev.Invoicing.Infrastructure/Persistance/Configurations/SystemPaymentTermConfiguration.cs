namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class SystemPaymentTermConfiguration : IEntityTypeConfiguration<SystemPaymentTerm>
{
    public void Configure(EntityTypeBuilder<SystemPaymentTerm> builder)
    {
        builder
            .ToTable("SystemPaymentTerm");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder
            .Property(x => x.DueInDays)
            .IsRequired();

        builder.HasData(new SystemPaymentTerm[] { 
            new SystemPaymentTerm { Id = 1, Name = "Due in 30", DueInDays = 30 },
            new SystemPaymentTerm { Id = 2, Name = "Due in 60", DueInDays = 60 },
            new SystemPaymentTerm { Id = 3, Name = "Due in 90", DueInDays = 90 },
        });
    }
}
