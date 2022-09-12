namespace TransDev.Invoicing.Application.Client.Commands;

using TransDev.Invoicing.Application.Common.Dtos;

public class CreateClientResponse
{
    public bool Success { get; set; }
    public ClientDto Client { get; set; }
}