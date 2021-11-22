using EFCoreWorkService;
using EFCoreWorkService.Data;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<EFDataContext>(opt => opt.UseInMemoryDatabase(databaseName: "Teste"), optionsLifetime: ServiceLifetime.Scoped);

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
