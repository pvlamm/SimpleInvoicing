using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Interfaces;

namespace TransDev.Invoicing.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
