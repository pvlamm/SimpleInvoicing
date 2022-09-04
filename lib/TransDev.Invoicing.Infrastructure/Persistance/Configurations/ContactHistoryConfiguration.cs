namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ContactHistoryConfiguration : IEntityTypeConfiguration<ContactHistory>
{
    public void Configure(EntityTypeBuilder<ContactHistory> builder)
    {
        throw new System.NotImplementedException();
    }
}
