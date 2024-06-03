using Worker.Installers;
using Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Workers>();
builder.Services.InstallerServiceInAssembly(builder.Configuration);

var host = builder.Build();
host.Run();
