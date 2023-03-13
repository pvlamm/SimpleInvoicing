namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ItemHistoryConfiguration : IEntityTypeConfiguration<ItemHistory>
{
    public void Configure(EntityTypeBuilder<ItemHistory> builder)
    {
        builder
            .ToTable("ItemHistory");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(a => a.Description)
            .HasMaxLength(2048);

        builder
            .Property(a => a.Price);

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
            .HasOne(a => a.Parent)
            .WithMany(a => a.History)
            .HasForeignKey(a => a.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.InvoiceDetails)
            .WithOne(x => x.Item)
            .HasForeignKey(x => x.ItemId);

    }
}
