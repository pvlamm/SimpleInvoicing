namespace TransDev.Invoicing.Domain.Entities;

using System;

using TransDev.Invoicing.Domain.BaseEntities;

public class AccountSubscription : HistoryEntityBase
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int SubscriptionId { get; set; }
    public virtual SystemSubscription Subscription { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime RenewalDate { get; set; }
    public DateTime CancelDate { get; set; }
}
