namespace TransDev.Invoicing.Application.Common.Dtos;

using System;
public class SystemUserDto
{
    public Guid PublicId { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
