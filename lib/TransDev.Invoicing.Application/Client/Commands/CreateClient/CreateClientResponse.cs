namespace TransDev.Invoicing.Application.Client.Commands;

using TransDev.Invoicing.Application.Common.Abstracts;
using TransDev.Invoicing.Application.Common.Dtos;

public sealed class CreateClientResponse : ResponseBase
{
    public ClientDto Client { get; set; }
}