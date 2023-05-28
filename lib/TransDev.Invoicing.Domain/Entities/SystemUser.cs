﻿namespace TransDev.Invoicing.Domain.Entities
{
    using System;

    public class SystemUser
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
