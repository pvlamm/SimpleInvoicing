namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ClientHistoryConfiguration : IEntityTypeConfiguration<ClientHistory>
{
    public void Configure(EntityTypeBuilder<ClientHistory> builder)
    {
        throw new NotImplementedException();
    }
}
