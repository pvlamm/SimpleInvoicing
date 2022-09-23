namespace TransDev.Invoicing.Application.Client.Queries;

using TransDev.Invoicing.Application.Common.Abstracts;
using TransDev.Invoicing.Application.Common.Dtos;

public class GetActiveClientsResponse : ResponseBase
{
    public SearchClientDto[] Clients { get; set; }
}
