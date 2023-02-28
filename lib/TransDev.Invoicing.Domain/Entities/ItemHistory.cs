﻿namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record ItemHistory : HistoryEntityBase
{
    public long Id { get; init; }
    public int ParentId { get; init; }
    public virtual Item Parent { get; init; }
    public string Description { get; init; }
    public int Price { get; init; }
}
