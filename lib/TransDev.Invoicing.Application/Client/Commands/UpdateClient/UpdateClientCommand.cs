namespace TransDev.Invoicing.Application.Client.Commands;

using MediatR;

public class UpdateClientCommand : IRequest<UpdateClientResponse>
{
    public int ClientId { get; set; }
    public string Name { get; set; }
}
