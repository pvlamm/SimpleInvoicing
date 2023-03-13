namespace TransDev.Invoicing.Domain.Entities;

using System.Collections.Generic;

public record Contact
{
    public int Id { get; init; }
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }

    public ICollection<ContactHistory> History { get; set; } = new HashSet<ContactHistory>();
}
