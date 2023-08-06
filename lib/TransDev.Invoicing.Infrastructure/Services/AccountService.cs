namespace TransDev.Invoicing.Infrastructure.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using TransDev.Invoicing.Application.Common.Interfaces;

    public class AccountService : IAccountService
    {
        public Task<bool> AccountExists(string username, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddUserToAccount(Guid publicId, Guid systemUserPublicId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateAccountAsync(string username, string password, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAccountActiveAsync(Guid publicId, bool active, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
