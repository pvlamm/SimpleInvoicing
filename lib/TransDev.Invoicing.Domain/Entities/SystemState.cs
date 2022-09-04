namespace TransDev.Invoicing.Domain.Entities;

using System.Collections.Generic;

public record SystemState
{
    public string Id { get; set; }
    public string Name { get; set; }

    public ICollection<SystemCity> Cities { get; set; } = new HashSet<SystemCity>();
}
