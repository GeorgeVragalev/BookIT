using Backend;

var builder = WebApplication.CreateBuilder(args);
Startup.ConfigureServices(builder);

var app = builder.Build();
Startup.Configure(app);