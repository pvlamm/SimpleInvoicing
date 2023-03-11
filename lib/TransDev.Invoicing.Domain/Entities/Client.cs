namespace TransDev.Invoicing.Domain.Entities;

using System;
using System.Collections.Generic;

using TransDev.Invoicing.Domain.Enums;

public record Client
{
    public int Id { get; init; }
    public Guid PublicId { get; init; } = Guid.NewGuid();
    public ClientType ClientType { get; init; }
    public ICollection<ClientHistory> History { get; init; } = new HashSet<ClientHistory>();
    public ICollection<Contact> Contacts { get; init; } = new HashSet<Contact>();
}
