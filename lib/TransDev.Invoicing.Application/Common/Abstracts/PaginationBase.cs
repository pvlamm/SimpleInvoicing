namespace TransDev.Invoicing.Application.Common.Abstracts;

public abstract class PaginationBase
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
}
