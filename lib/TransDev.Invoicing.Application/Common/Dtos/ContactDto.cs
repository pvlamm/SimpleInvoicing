namespace TransDev.Invoicing.Application.Common.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public class ContactDto
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }

    public ContactHistory ConvertToContactHistory()
    {
        return new ContactHistory()
        {
            FirstName= FirstName,
            MiddleName=MiddleName,
            LastName= LastName,
            EmailAddress= EmailAddress,
            PhoneNumber= PhoneNumber
        };
    }
}
