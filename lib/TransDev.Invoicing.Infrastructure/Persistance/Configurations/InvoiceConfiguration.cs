namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoice");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.PublicId)
            .IsRequired();

        builder.Property(x => x.Number)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(x => x.ClientId)
            .IsRequired();

        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.ClientId);

        builder
            .HasOne(x => x.Contact)
            .WithMany()
            .HasForeignKey(x => x.ContactId);

        builder
            .HasOne(x => x.SystemPaymentTerm)
            .WithMany()
            .HasForeignKey(x => x.SystemPaymentTermId);

        builder
            .Property(x => x.Invoiced)
            .IsRequired(false)
            .HasColumnType("date");

        builder
            .Property(x => x.DueDate)
            .IsRequired(false)
            .HasColumnType("date");
    }
}
