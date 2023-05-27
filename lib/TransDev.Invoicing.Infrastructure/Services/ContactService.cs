namespace TransDev.Invoicing.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using TransDev.Invoicing.Application.Common.Interfaces;
    using TransDev.Invoicing.Domain.Entities;

    internal class ContactService : IContactService
    {
        public Task<bool> ContactExists(int contactId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ContactHistory> CreateContactAsync(long clientId, string firstName, string middleName, string lastName, string emailAddress, string phoneNumber, SystemAddress systemAddress, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteContactAsync(int contactId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ContactHistory> GetContactByContactHistoryIdAsync(long contactHistoryId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ContactHistory> GetContactByContactId(int contactId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactHistory>> GetContactHistoryByIdAsync(int contactId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactHistory>> GetContactsForClientIdAsync(int clientId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ContactHistory> UpdateContactAsync(ContactHistory contactHistory, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
