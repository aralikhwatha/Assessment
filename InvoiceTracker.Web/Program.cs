using InvoiceTracker.Web.ServiceConfiguration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationService(builder.Configuration["Messeging:server"], builder.Configuration["Messeging:Username"], builder.Configuration["Messeging:Password"]);
builder.Services.AddPersistenceServices();
builder.Services.AddIntegrationService();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.AddMiddleware();
app.MapControllers();

app.Run();
