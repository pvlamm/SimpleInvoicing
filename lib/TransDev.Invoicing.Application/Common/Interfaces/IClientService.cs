namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;
using TransDev.Invoicing.Domain.Enums;

public interface IClientService
{
    /// <summary>
    /// Returns Current "Active" ClientHistory status of Active Client List
    /// </summary>
    /// <param name="token"></param>
    /// <returns>List of Active/Current Clients</returns>
    Task<IEnumerable<ClientHistory>> GetActiveClientsAsync(CancellationToken token);
    /// <summary>
    /// Historical Lookup for a specific clientId
    /// </summary>
    /// <param name="clientId">Targeting client by Id</param>
    /// <param name="token"></param>
    /// <returns>Complete History to provided clientId</returns>
    Task<IEnumerable<ClientHistory>> GetClientHistoryAsync(int clientId, CancellationToken token);
    Task<bool> ClientExistsAsync(string name, CancellationToken token);
    /// <summary>
    /// Checks by Client.Id will review the current
    /// ClientHistory state and check the IsActive flag
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<bool> ClientIsActiveAsync(int clientId, CancellationToken token);
    Task<bool> UpdateClientAsync(ClientHistory clientHistory, CancellationToken token);
    /// <summary>
    /// Provide new Client record
    /// </summary>
    /// <param name="client">New Client Record</param>
    /// <param name="token">Cancellation Token</param>
    /// <returns>Newly Created ClientHistory Record with Parent/Client entry</returns>
    Task CreateClientAsync(Client client, CancellationToken token);
    Task CreateClientAsync(ClientType clientType, ClientHistory clientHistory,
        ContactHistory primaryContactHistory, ContactHistory billingContactHistory,
        SystemAddress primaryAddress, SystemAddress billingAddress, CancellationToken token);
}