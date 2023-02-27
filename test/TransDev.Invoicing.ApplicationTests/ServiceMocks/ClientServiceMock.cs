namespace TransDev.Invoicing.ApplicationTests.ServiceMocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;
using TransDev.Invoicing.Domain.Enums;

public class ClientServiceMock : IClientService
{
    public Task<bool> ClientExistsAsync(string name, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ClientIsActiveAsync(int clientId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task CreateClientAsync(Client client, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task CreateClientAsync(ClientType clientType, ClientHistory clientHistory, ContactHistory primaryContactHistory, ContactHistory billingContactHistory, SystemAddress primaryAddress, SystemAddress billingAddress, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClientHistory>> GetActiveClientsAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ClientHistory>> GetClientHistoryAsync(int clientId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateClientAsync(ClientHistory clientHistory, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
