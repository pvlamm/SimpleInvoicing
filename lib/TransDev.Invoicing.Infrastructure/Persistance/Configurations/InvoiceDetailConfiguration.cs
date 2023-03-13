namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        builder
            .ToTable("InvoiceDetail");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(x => x.Parent)
            .WithMany(x => x.Details)
            .HasForeignKey(x => x.ParentId);

        builder
            .Property(x => x.ParentId)
            .IsRequired();

        builder
            .HasOne(x => x.Item)
            .WithMany(x => x.InvoiceDetails)
            .HasForeignKey(x => x.ItemId);

        builder
            .Property(x => x.SequenceNumber)
            .HasColumnType("SMALLINT")
            .IsRequired();

        builder
            .Property(x => x.Cost)
            .HasColumnType("DECIMAL(15,5)")
            .IsRequired()
            .HasDefaultValue(0);

        builder
            .Property(x => x.Quantity)
            .HasColumnType("DECIMAL(15,5)")
            .IsRequired()
            .HasDefaultValue(0);

        builder
            .Property(x => x.Price)
            .HasColumnType("DECIMAL(15,5)")
            .IsRequired()
            .HasDefaultValue(0);

    }
}