namespace TransDev.Invoicing.Application.Common.Dtos;

using System;

using TransDev.Invoicing.Application.Common.Helpers;
using TransDev.Invoicing.Domain.Entities;

public class ClientDto
{
	public ClientDto()
	{

	}

	public ClientDto(ClientHistory clientHistory)
	{
		if(clientHistory != null)
		{
			this.Id = clientHistory.Parent?.PublicId ?? Guid.Empty;
			this.Name = clientHistory.Name ?? string.Empty;
			var primaryContact = clientHistory.PrimaryContact.History.CurrentHistory();
			var primaryBillingContact = clientHistory.PrimaryBillingContact.History.CurrentHistory();

            this.PrimaryContactName = $"{primaryContact.FirstName} {primaryContact.LastName}".Trim();
			this.PrimaryContactEmail = primaryContact.EmailAddress;
			this.PrimaryContactPhone = primaryContact.PhoneNumber;

			this.BillingContactName = $"{primaryBillingContact.FirstName} {primaryBillingContact.LastName}".Trim();
			this.BillingContactEmail = primaryBillingContact.EmailAddress;
			this.BillingContactPhone = primaryBillingContact.PhoneNumber;
		}
	}

	public Guid Id { get; set; }
    public string Name { get; set; }

	public string PrimaryContactName { get; set; }
	public string PrimaryContactEmail { get; set; }
	public string PrimaryContactPhone { get; set; }

	public string BillingContactName { get; set; }
	public string BillingContactEmail { get; set; }
	public string BillingContactPhone { get; set; }

}
