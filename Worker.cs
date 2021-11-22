using EFCoreWorkService.Data;

namespace EFCoreWorkService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHost host;

        public Worker(ILogger<Worker> logger, IHost host)
        {
            _logger = logger;
            this.host = host;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var serviceScope = host.Services.CreateScope();
            var services = serviceScope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<EFDataContext>();

                context.Usuarios.Add(new Models.UserModel
                {
                    Id = Guid.NewGuid(),
                    Nome = "Cássio"
                });
                await context.SaveChangesAsync(stoppingToken);

                while (!stoppingToken.IsCancellationRequested)
                {
                    var user = context.Usuarios.First();
                    _logger.LogInformation($"{user.Nome} - {DateTimeOffset.Now}");
                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "ERR =(");
            }

        }
    }
}