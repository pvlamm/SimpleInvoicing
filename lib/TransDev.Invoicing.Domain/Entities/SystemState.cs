namespace TransDev.Invoicing.Domain.Entities;

using System;
using System.Collections.Generic;

public record SystemState
{
    public SystemState()
    {

    }

    public SystemState(string stateId)
    {
        if (string.IsNullOrWhiteSpace(stateId) || stateId.Length != 2)
        {
            throw new ArgumentOutOfRangeException(nameof(stateId), $"{stateId} is invalid");
        }

        this.Id = stateId;
    }

    public string Id { get; set; }
    public string Name { get; set; }

    public ICollection<SystemCity> Cities { get; set; } = new HashSet<SystemCity>();
}
