
using InvoiceTracker.Application.Feature.Invoice.Commands;
using MediatR;

namespace InvoiceTracker.Endpoint.Services
{
    public class EscalationService : BackgroundService
    {
        private readonly ILogger<EscalationService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public EscalationService(ILogger<EscalationService> logger, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            
        }
        protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Escalation task starting.");

            using PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromSeconds(int.Parse(_configuration["Escalation:lapseTime"])));

            while (!stoppingToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    _logger.LogInformation("Processing Escalation task at: {time}", DateTimeOffset.Now);

                    // Place your heavy logic here (e.g., polling database, processing messages)
                    await DoWorkAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while executing the Escalation task.");
                }
            }

            _logger.LogInformation("Escalation Service is stopping.");
        }

        private async Task DoWorkAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(new SendEscalationNotificationCommand(), cancellationToken);
            }
        }
    }
}
