namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ClientHistoryConfiguration : IEntityTypeConfiguration<ClientHistory>
{
    public void Configure(EntityTypeBuilder<ClientHistory> builder)
    {
        builder.ToTable("ClientHistory");
        builder.HasKey(x => x.Id);

        builder.HasOne(a => a.AuditTrail).WithMany().IsRequired().HasForeignKey(a => a.AuditTrailId);
        builder.HasOne(a => a.UpdatedAuditTrail).WithMany().IsRequired(false).HasForeignKey(a => a.UpdatedAuditTrailId);

    }
}
