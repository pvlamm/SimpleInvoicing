namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class AuditTrailConfiguration : IEntityTypeConfiguration<AuditTrail>
{
    public void Configure(EntityTypeBuilder<AuditTrail> builder)
    {
        builder.ToTable("AuditTrail");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.CreatedDate).IsRequired();
        builder.Property(a => a.Note).HasMaxLength(1024);
    }
}
