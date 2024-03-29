﻿namespace TransDev.Invoicing.Application.Common.Dtos;

using TransDev.Invoicing.Domain.Entities;

public class AddressDto
{
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public SystemAddress ConvertToSystemAddress()
    {
        return new SystemAddress
        {
            Address = this.Address,
            City = this.City,
            SystemStateId = this.State,
            ZipCode = this.ZipCode,
        };
    }
}
