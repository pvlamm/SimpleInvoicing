namespace TransDev.Invoicing.Domain.Entities;

using System.Collections.Generic;

using TransDev.Invoicing.Domain.Enums;

public record Item
{
    public int Id { get; init; }
    public string Code { get; set; }
    public ItemType Type { get; set; }
    public ICollection<ItemHistory> History { get; set; } = new HashSet<ItemHistory>();
}
