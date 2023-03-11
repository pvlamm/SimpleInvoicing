namespace TransDev.Invoicing.Domain.Entities;

using System.Collections.Generic;

using TransDev.Invoicing.Domain.Enums;

public record Item
{
    public int Id { get; init; }
    public string Code { get; init; }
    public ItemType Type { get; init; }
    public ICollection<ItemHistory> History { get; init; } = new HashSet<ItemHistory>();
}
