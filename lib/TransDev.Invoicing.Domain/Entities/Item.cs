namespace TransDev.Invoicing.Domain.Entities;

using System;
using System.Collections.Generic;

using TransDev.Invoicing.Domain.Enums;

public record Item
{
    public int Id { get; init; }
    public virtual Account Account { get; set; }
    public int AccountId { get; set; }
    public string Code { get; set; }
    public ItemType Type { get; set; }
    public ICollection<ItemHistory> History { get; set; } = new HashSet<ItemHistory>();
}
