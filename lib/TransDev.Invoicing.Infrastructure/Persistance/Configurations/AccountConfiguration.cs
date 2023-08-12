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

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.PublicId);

            builder.Property(x => x.Name)
                .HasMaxLength(75)
                .IsRequired();

            //builder.HasMany(x => x.Invoices)
            //    .WithOne(x => x.Account)
            //    .HasForeignKey(x => x.AccountId);

            //builder.HasMany(x => x.Clients)
            //    .WithOne(x => x.Account)
            //    .HasForeignKey(x => x.AccountId);

        }
    }
}
