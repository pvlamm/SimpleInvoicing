namespace TransDev.Invoicing.Application.Common.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.BaseEntities;

public static class HistoryEntityBaseExtensions
{
    public static T CurrentHistory<T>(this ICollection<T> collection) 
        where T : HistoryEntityBase
    {
        if(collection != null)
        {
            return collection.LastOrDefault(x => x.UpdatedAuditTrailId == null);
        }

        return null;
    }
}
