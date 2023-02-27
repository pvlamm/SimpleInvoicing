namespace TransDev.Invoicing.Application.Authentication.Queries.AuthenticateUser;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Abstracts;

public class AuthenticateUserResponse : ResponseBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    [JsonPropertyName("api_token")]
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}