namespace TransDev.Invoicing.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public record Account
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Client> Clients { get; set; } = new HashSet<Client>();
        public IEnumerable<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    }
}
