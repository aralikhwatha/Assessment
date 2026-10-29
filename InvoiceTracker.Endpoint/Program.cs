using InvoiceTracker.Endpoint.ServiceConfiguration;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddEndpoint();
builder.Services.AddApplicationService();
builder.Services.AddPersistenceServices();
builder.Services.AddIntegrationService();
builder.Services.AddConsumerService(builder.Configuration["Messeging:server"], builder.Configuration["Messeging:Username"], builder.Configuration["Messeging:Password"], builder.Configuration["Messeging:Queue"]);



var host = builder.Build();
host.Run();
