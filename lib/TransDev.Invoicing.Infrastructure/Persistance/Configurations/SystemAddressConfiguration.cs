namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class SystemAddressConfiguration : IEntityTypeConfiguration<SystemAddress>
{
    public void Configure(EntityTypeBuilder<SystemAddress> builder)
    {
        throw new NotImplementedException();
    }
}
