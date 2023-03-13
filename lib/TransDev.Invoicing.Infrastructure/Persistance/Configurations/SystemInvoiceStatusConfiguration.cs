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
            .Property(x => x.StatusType)
            .HasColumnType("SMALLINT")
            .IsRequired();

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(512);

        builder
            .HasData(new SystemInvoiceStatus[] {
                new SystemInvoiceStatus()
                {
                    Id = 0,
                    Name = "Detailing",
                    Description = "For Invoices not ready Invoicing",
                    StatusType = Domain.Enums.InvoiceStatusType.Detailling
                },
                new SystemInvoiceStatus()
                {
                    Id = 1,
                    Name = "Opened",
                    Description = "Invoice is ready for Invoicing",
                    StatusType = Domain.Enums.InvoiceStatusType.Open
                },
                new SystemInvoiceStatus()
                {
                    Id = 2,
                    Name = "Invoiced",
                    Description = "This item has been Invoiced",
                    StatusType = Domain.Enums.InvoiceStatusType.Invoiced
                },
                new SystemInvoiceStatus()
                {
                    Id = 3,
                    Name = "Closed",
                    Description = "Invoice has been paid in full",
                    StatusType = Domain.Enums.InvoiceStatusType.Closed
                },
                new SystemInvoiceStatus()
                {
                    Id = 4,
                    Name = "Cancelled",
                    Description = "Invoice has been cancelled",
                    StatusType = Domain.Enums.InvoiceStatusType.Cancelled
                }
            });
    }
}
