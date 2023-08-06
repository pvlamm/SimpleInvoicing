namespace TransDev.Invoicing.Domain.Entities;

using System;

public class SystemSubscription
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? UpdateToSubscription { get; set; }
}
