namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using TransDev.Invoicing.Domain.Entities;

    public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable("SystemUser");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Email)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.DisplayName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PublicId)
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .HasDefaultValue(Guid.NewGuid());
        }
    }
}
