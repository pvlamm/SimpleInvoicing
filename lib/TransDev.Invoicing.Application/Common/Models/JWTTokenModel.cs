using Newtonsoft.Json;
using System;

namespace TransDev.Invoicing.Application.Common.Models
{
    public class JWTTokenModel
    {
        [JsonRequired()]
        public string Token { get; set; }

        [JsonRequired()]
        public DateTime ExpiresAt { get; set; }
    }
}
