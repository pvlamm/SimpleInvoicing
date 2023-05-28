namespace TransDev.Invoicing.Domain.Entities;

using System;

public class AuditTrail
{
    public long Id { get; init; }
    public int UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Note { get; init; }
}
