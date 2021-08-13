using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Domain.Entities;

namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations
{
    public class AuditTrailConfiguration : IEntityTypeConfiguration<AuditTrail>
    {
        public void Configure(EntityTypeBuilder<AuditTrail> builder)
        {
            builder.ToTable("AuditTrail");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(512);
        }
    }
}
