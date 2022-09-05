namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ContactHistoryConfiguration : IEntityTypeConfiguration<ContactHistory>
{
    public void Configure(EntityTypeBuilder<ContactHistory> builder)
    {
        builder
            .ToTable("ContactHistory");

        builder
            .HasKey(x => x.Id);

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
            .HasOne(history => history.Parent)
            .WithMany(contact => contact.History)
            .HasForeignKey(history => history.ParentId);

        builder
            .HasOne(history => history.Address)
            .WithMany()
            .HasForeignKey(history => history.SystemAddressId);

        builder
            .Property(history => history.FirstName)
            .HasMaxLength(55)
            .IsRequired();

        builder
            .Property(history => history.MiddleName)
            .HasMaxLength(55)
            .IsRequired();

        builder
            .Property(history => history.LastName)
            .HasMaxLength(55)
            .IsRequired();

        builder
            .Property(history => history.EmailAddress)
            .HasMaxLength(120)
            .IsRequired();

        builder
            .Property(history => history.PhoneNumber)
            .HasMaxLength(15)
            .IsRequired();


    }
}
