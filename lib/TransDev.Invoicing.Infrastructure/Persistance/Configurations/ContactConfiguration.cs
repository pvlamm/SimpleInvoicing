namespace TransDev.Invoicing.Infrastructure.Persistance.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TransDev.Invoicing.Domain.Entities;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder
            .ToTable("Contact");

        builder
            .HasKey(contact => contact.Id);

        builder
            .HasOne(contact => contact.Client)
            .WithMany(client => client.Contacts)
            .HasForeignKey(contact => contact.ClientId);
    }
}
