using Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Workers>();

var host = builder.Build();
host.Run();
