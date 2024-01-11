using System;

namespace dosLogistic.API.Brokers.DataTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTime() =>
             DateTimeOffset.UtcNow;
    }
}
