namespace TransDev.Invoicing.Domain.Entities;

using System;

public record AuditTrail
{
    public long Id { get; init; }
    public DateTime CreatedDate { get; init; }
    public string Note { get; init; }
}
