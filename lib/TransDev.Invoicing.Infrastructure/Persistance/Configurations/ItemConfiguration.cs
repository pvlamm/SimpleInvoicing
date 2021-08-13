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
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Code).IsRequired().HasMaxLength(16);

            builder.HasMany(a => a.ItemHistories).WithOne(a => a.Parent).HasForeignKey(a => a.ParentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
