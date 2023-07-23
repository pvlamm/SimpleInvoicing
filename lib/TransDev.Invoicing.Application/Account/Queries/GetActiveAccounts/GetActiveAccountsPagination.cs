namespace TransDev.Invoicing.Application.Account.Queries;

using System;

using TransDev.Invoicing.Application.Common.Abstracts;

public class GetActiveAccountsPagination : PaginationBase<ActiveAccount>
{
}

public class ActiveAccount
{
    public Guid PublicId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string PrimaryContact { get; set; }
    public Guid PrimaryContactPublicId { get; set; }
    public string PrimaryBillingContact { get; set; }
    public Guid PrimaryBillingContactPrimaryId { get; set; }
}