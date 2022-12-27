namespace TransDev.Invoicing.Application.Common.Dtos;

using System;
using System.Linq;

using TransDev.Invoicing.Domain.Entities;

public class SearchClientDto
{
    public SearchClientDto(ClientHistory history)
    {
        if(history == null) throw new ArgumentNullException(nameof(history));

        var primaryContact = GetCurrentContact(history.PrimaryContact);
        var billingContact = GetCurrentContact(history.PrimaryBillingContact);

        Name = history.Name;

        if (primaryContact != null)
        {
            PrimaryContactName = $"{primaryContact.LastName}, {primaryContact.FirstName}";
            PrimaryContactEmail = $"{primaryContact.EmailAddress}";
            PrimaryContactPhone = $"{primaryContact.PhoneNumber}";
        }

        if (billingContact != null)
        {
            BillingContactName = $"{billingContact.LastName}, {billingContact.FirstName}";
            BillingContactEmail = $"{primaryContact.EmailAddress}";
            BillingContactPhone = $"{primaryContact.PhoneNumber}";
        }
    }

    public SearchClientDto()
    {

    }

    private ContactHistory GetCurrentContact(Contact contact)
    {
        return contact.History?
            .FirstOrDefault(history => history.UpdatedAuditTrailId == null);
    }

    public string Name { get; set; }
    public string PrimaryContactName { get; set; }
    public string PrimaryContactEmail { get; set; }
    public string PrimaryContactPhone { get; set; }
    public string BillingContactName { get; set; }
    public string BillingContactEmail { get; set; }
    public string BillingContactPhone { get; set; }
}