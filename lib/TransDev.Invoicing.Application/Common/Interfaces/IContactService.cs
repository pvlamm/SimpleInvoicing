namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface IContactService
{
    Task<ContactHistory> CreateContactAsync(long clientId, string firstName, string middleName, string lastName, string emailAddress, string phoneNumber, SystemAddress systemAddress, CancellationToken token);
    Task<IEnumerable<ContactHistory>> GetContactsForClientIdAsync(int clientId, CancellationToken token);
    Task<IEnumerable<ContactHistory>> GetContactHistoryByIdAsync(int contactId, CancellationToken token);
    Task<ContactHistory> UpdateContactAsync(ContactHistory contactHistory, CancellationToken token);
    Task<bool> DeleteContactAsync(int contactId, CancellationToken token);
    Task<ContactHistory> GetContactByContactHistoryIdAsync(long contactHistoryId, CancellationToken token);
    Task<ContactHistory> GetContactByContactId(int contactId, CancellationToken token);
}   
