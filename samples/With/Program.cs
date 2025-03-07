using With;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging((c, b) =>
    {
        b.AddSimpleConsole(o => { o.SingleLine = true; });
    })
    .ConfigureServices(services =>
    {
        services.Configure<HostOptions>(hostOptions =>
        {
            hostOptions.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
        });
        services.AddHttpClient();
        services.UseMinimalHttpLogger();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
