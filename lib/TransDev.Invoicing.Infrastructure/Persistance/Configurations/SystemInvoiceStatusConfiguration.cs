namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class SystemInvoiceStatusConfiguration : IEntityTypeConfiguration<SystemInvoiceStatus>
{
    public void Configure(EntityTypeBuilder<SystemInvoiceStatus> builder)
    {
        builder
            .ToTable("SystemInvoiceStatus");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(15);

        builder
            .Property(x => x.Quote)

        builder
            .Property(x => x.IsClosed)
            .IsRequired()
            .HasDefaultValue(false);

        builder
            .Property(x => x.IsCancelled)
            .IsRequired()
            .HasDefaultValue(false);

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(512);


    }
}
