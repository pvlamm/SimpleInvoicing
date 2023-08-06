namespace TransDev.Invoicing.Infrastructure.Services
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using TransDev.Invoicing.Application.Common.Interfaces;
    using TransDev.Invoicing.Domain.Entities;

    public class AccountService : IAccountService
    {
        private readonly IApplicationDbContext _dbConext;
        private readonly IDateTimeService _dateTimeService;

        public AccountService(IApplicationDbContext dbContext, IDateTimeService dateTimeService)
        {
            _dbConext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public bool AccountExists(string username, CancellationToken token)
        {
            return _dbConext.Accounts.Any(x => x.Name == username);
        }

        public async Task<bool> AddUserToAccount(Guid publicId, Guid systemUserPublicId, CancellationToken token)
        {
            return false;
        }

        public async Task<Guid> CreateAccountAsync(string username, string password, CancellationToken token)
        {
            var account = new Account
            {
                Name = $"{username} Company",
                Users = new[] { new SystemUser { Email = username, DisplayName = username } },
                PublicId = Guid.NewGuid()
            };

           await _dbConext.Accounts.AddAsync(account, token);
           await _dbConext.SaveChangesAsync(token);

            return account.PublicId;
        }

        public async Task<bool> SetAccountActiveAsync(Guid publicId, bool active, CancellationToken token)
        {
            return active;
        }
    }
}
