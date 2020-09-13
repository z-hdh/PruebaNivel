using System;

namespace Prueba.Services.CronJobs.Support
{
    public interface IScheduleConfig<T>
    {
        string CronExpression { get; set; }

        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
