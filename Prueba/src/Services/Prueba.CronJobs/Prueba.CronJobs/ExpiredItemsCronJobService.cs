using Microsoft.Extensions.Logging;
using Prueba.Application.Services;
using Prueba.Services.CronJobs;
using Prueba.Services.CronJobs.Support;
using System;
using System.Threading;
using System.Threading.Tasks;
using CrossCutting.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Prueba.CronJobs
{
    public class ExpiredItemsCronJobService : CronJobService
    {
        private readonly ILogger<ExpiredItemsCronJobService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ExpiredItemsCronJobService(IScheduleConfig<ExpiredItemsCronJobService> config, ILogger<ExpiredItemsCronJobService> logger, IServiceScopeFactory serviceScopeFactory)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ExpiredItemsCronJobService starts.");

            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} ExpiredItemsCronJobService is working.");

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var productService = scope.ServiceProvider.GetRequiredService<IProductServices>();

                productService.NotifyExpiredProducts();
            }

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("ExpiredItemsCronJobService is stopping.");

            return base.StopAsync(cancellationToken);
        }
    }
}
