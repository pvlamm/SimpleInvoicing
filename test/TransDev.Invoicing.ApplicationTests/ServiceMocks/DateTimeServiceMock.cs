namespace TransDev.Invoicing.ApplicationTests.ServiceMocks;

using System;

using TransDev.Invoicing.Application.Common.Interfaces;

public class DateTimeServiceMock : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;
}
