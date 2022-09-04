namespace TransDev.Invoicing.Domain.Entities;

using System;

public record AuditTrail
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Note { get; set; }
}
