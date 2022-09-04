namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ContactHistoryConfiguration : IEntityTypeConfiguration<ContactHistory>
{
    public void Configure(EntityTypeBuilder<ContactHistory> builder)
    {
        builder.ToTable("ContactHistory");
        builder.HasKey(x => x.Id);

        builder.HasOne(a => a.AuditTrail).WithMany().IsRequired().HasForeignKey(a => a.AuditTrailId);
        builder.HasOne(a => a.UpdatedAuditTrail).WithMany().IsRequired(false).HasForeignKey(a => a.UpdatedAuditTrailId);

        builder.HasOne(history => history.Parent)
            .WithMany(contact => contact.History)
            .HasForeignKey(history => history.ParentId);


    }
}
