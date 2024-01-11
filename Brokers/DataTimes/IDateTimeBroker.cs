using System;

namespace dosLogistic.API.Brokers.DataTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset GetCurrentDateTime();
    }
}
