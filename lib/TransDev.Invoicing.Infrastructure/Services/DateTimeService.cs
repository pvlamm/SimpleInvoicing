namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Interfaces;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;
}
