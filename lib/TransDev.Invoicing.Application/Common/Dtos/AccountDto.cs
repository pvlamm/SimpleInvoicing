namespace TransDev.Invoicing.Application.Common.Dtos;

public class AccountDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public AddressDto MailingAddress { get; set; }
    public AddressDto BillingAddress { get; set; }

}
