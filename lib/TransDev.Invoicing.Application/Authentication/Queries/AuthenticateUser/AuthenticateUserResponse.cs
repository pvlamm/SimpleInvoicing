using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Abstracts;

namespace TransDev.Invoicing.Application.Authentication.Queries.AuthenticateUser
{
    public class AuthenticateUserResponse : ResponseBase
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Username { get; set; }
    }
}
