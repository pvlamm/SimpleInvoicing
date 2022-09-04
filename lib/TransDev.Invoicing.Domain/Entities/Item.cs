namespace TransDev.Invoicing.Domain.Entities;

using System.Collections.Generic;

using TransDev.Invoicing.Domain.Enums;

public record Item
{
    public int Id { get; set; }
    public string Code { get; set; }
    public ItemType Type { get; set; }
    public ICollection<ItemHistory> ItemHistories { get; set; } = new HashSet<ItemHistory>();
}
