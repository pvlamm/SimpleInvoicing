namespace TransDev.Invoicing.Domain.Entities;

using System.Collections.Generic;

using TransDev.Invoicing.Domain.Enums;

public record Client
{
    public int Id { get; set; }
    public ClientType ClientType { get; set; }
    public ICollection<ClientHistory> History { get; set; } = new HashSet<ClientHistory>();
    public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
}
