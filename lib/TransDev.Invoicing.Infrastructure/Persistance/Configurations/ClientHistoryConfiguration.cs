﻿namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ClientHistoryConfiguration : IEntityTypeConfiguration<ClientHistory>
{
    public void Configure(EntityTypeBuilder<ClientHistory> builder)
    {
        builder
            .ToTable("ClientHistory");

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
            .WithMany(client => client.History)
            .HasForeignKey(history => history.ParentId);

        builder
            .HasOne(history => history.PrimaryAddress)
            .WithMany()
            .HasForeignKey(history => history.PrimarySystemAddressId);

        builder
            .HasOne(history => history.BillingAddress)
            .WithMany()
            .HasForeignKey(history => history.BillingSystemAddressId);

        builder
            .HasOne(history => history.PrimaryContact)
            .WithMany()
            .HasForeignKey(history => history.PrimaryContactId);

        builder
            .HasOne(history => history.PrimaryBillingContact)
            .WithMany()
            .HasForeignKey(history => history.PrimaryBillingContactId);

        builder
            .Property(history => history.Name)
            .IsRequired()
            .HasMaxLength(65);
    }
}
