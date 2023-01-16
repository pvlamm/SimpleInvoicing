namespace TransDev.Invoicing.Application.Common.Dtos;

using TransDev.Invoicing.Domain.Entities;

public class AddressDto
{
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public SystemAddress ConvertToSystemAddress()
    {
        var systemState = new SystemState(this.State)
        {

        };

        var systemCity = new SystemCity()
        {
            State = systemState,
            SystemStateId = systemState.Id,
        };

        return new SystemAddress
        {
            Address = this.Address,
            ZipCode = this.ZipCode,
            City = new SystemCity()
            {
                Name = this.City,
                State
            }
        }
    }
}
