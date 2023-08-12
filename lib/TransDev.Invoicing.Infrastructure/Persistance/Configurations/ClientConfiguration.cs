namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");
        builder.HasKey(client => client.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.HasAlternateKey(client => client.PublicId);

        builder.HasMany(client => client.Contacts)
            .WithOne(contact => contact.Client)
            .HasForeignKey(contact => contact.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(client => client.History)
            .WithOne(history => history.Parent)
            .HasForeignKey(history => history.ParentId)
            .OnDelete(DeleteBehavior.Cascade);

        //builder.HasOne(x => x.Account)
        //    .WithMany(x => x.Clients)
        //    .HasForeignKey(x => x.AccountId)
        //    .OnDelete(DeleteBehavior.Cascade);
    }
}
