﻿namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Threading.Tasks;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(string username, string password);
}
