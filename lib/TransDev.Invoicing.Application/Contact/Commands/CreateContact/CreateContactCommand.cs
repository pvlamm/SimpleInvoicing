namespace TransDev.Invoicing.Application.Contact.Commands;

using System.Threading;
using System.Threading.Tasks;

using MediatR;

public sealed class CreateContactCommand : IRequest<CreateContactResponse>
{
    public int ClientId { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsBilling { get; set; }

    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public int CityId { get; set; } = 0;
    public string State { get; set; }
    public string ZipCode { get; set; }
}

public sealed class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreateContactResponse>
{
    public CreateContactCommandHandler()
    {

    }

    public async Task<CreateContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        return new CreateContactResponse { };
    }
}
