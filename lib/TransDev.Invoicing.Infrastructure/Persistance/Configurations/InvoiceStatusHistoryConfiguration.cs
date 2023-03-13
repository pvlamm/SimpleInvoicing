namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class InvoiceStatusHistoryConfiguration : IEntityTypeConfiguration<InvoiceStatusHistory>
{
    public void Configure(EntityTypeBuilder<InvoiceStatusHistory> builder)
    {
        builder
            .ToTable("InvoiceStatusHistory");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(a => a.AuditTrail)
            .WithMany()
            .IsRequired()
            .HasForeignKey(a => a.AuditTrailId);

        builder
            .HasOne(a => a.UpdatedAuditTrail)
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(a => a.UpdatedAuditTrailId);

        builder
            .HasOne(x => x.Parent)
            .WithMany(x => x.StatusHistory)
            .HasForeignKey(x => x.ParentId);

        builder
            .Property(x => x.ParentId)
            .IsRequired();

        builder
            .HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.SystemInvoiceStatusId);

        builder
            .Property(x => x.SystemInvoiceStatusId)
            .IsRequired();
    }
}