namespace TransDev.Invoicing.Domain.Entities;

using System;
using System.Collections.Generic;

public record Invoice
{
    public int Id { get; init; }
    public Guid PublicId { get; set; }
    //public virtual Account Account { get; set; }
    //public int AccountId { get; set; }
    public string Number { get; set; }
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }
    public int ContactId { get; set; }
    public virtual Contact Contact { get; set; }
    public byte SystemPaymentTermId { get; set; }
    public virtual SystemPaymentTerm SystemPaymentTerm { get; set; }
    public DateOnly? Invoiced { get; set; }
    public DateOnly? DueDate { get; set; }
    public ICollection<InvoiceDetail> Details { get; set; } = new HashSet<InvoiceDetail>();
    public ICollection<InvoiceStatusHistory> StatusHistory { get; set; } = new HashSet<InvoiceStatusHistory>();
}
