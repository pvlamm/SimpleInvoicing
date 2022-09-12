﻿namespace TransDev.Invoicing.Application.Common.Interfaces;

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
    /// Historical Lookup for a specific clientId
    /// </summary>
    /// <param name="clientId">Targeting client by Id</param>
    /// <param name="token"></param>
    /// <returns>Complete History to provided clientId</returns>
    Task<IEnumerable<ClientHistory>> GetClientHistoryAsync(int clientId, CancellationToken token);
    Task<bool> ClientExistsAsync(string name, CancellationToken token);
    /// <summary>
    /// Provide a ClientHistory record with Parent/Client to get Created anew;
    /// Method will 0 out Ids.
    /// </summary>
    /// <param name="history"></param>
    /// <param name="token"></param>
    /// <returns>Newly Created ClientHistory Record with Parent/Client entry</returns>
    Task<ClientHistory> CreateClientAsync(ClientHistory history, CancellationToken token);
}
