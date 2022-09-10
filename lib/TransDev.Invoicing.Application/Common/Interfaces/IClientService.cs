namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface IClientService
{
    /// <summary>
    /// Returns Current "Active" ClientHistory status of Active Client List
    /// </summary>
    /// <param name="token"></param>
    /// <returns>List of Active/Current Clients</returns>
    Task<IEnumerable<ClientHistory>> GetActiveClientsAsync(CancellationToken token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="clientId">Specific Client with Current Status</param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<Client> GetClientByClientIdAsync(int clientId, CancellationToken token);
    /// <summary>
    /// Historical Lookup for a specific clientId
    /// </summary>
    /// <param name="clientId">Targeting client by Id</param>
    /// <param name="token"></param>
    /// <returns>Complete History to provided clientId</returns>
    Task<IEnumerable<ClientHistory>> GetClientHistoryAsync(int clientId, CancellationToken token);

}
