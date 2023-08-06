namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class AccountSubscriptionConfiguration : IEntityTypeConfiguration<AccountSubscription>
{
    public void Configure(EntityTypeBuilder<AccountSubscription> builder)
    {
        builder.ToTable(nameof(AccountSubscription));
        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(x => x.ParentId);

        builder
            .HasOne(x => x.Parent)
            .WithMany()
            .IsRequired()
            .HasForeignKey(x => x.ParentId);

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
            .HasOne(x => x.Subscription)
            .WithMany()
            .IsRequired()
            .HasForeignKey(a => a.SubscriptionId);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.BeginDate).IsRequired();
        builder.Property(x => x.RenewalDate).IsRequired();
        builder.Property(x => x.CancelDate).IsRequired(false);
    }
}
