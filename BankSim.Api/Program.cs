using BankSim.Api.Middlewares;
using BankSim.Domain.Services;
using BankSim.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IStatementService, StatementService>();
builder.Services.AddSingleton<IAccountStore, InMemoryAccountStore>();
builder.Services.AddSingleton<ITransferService, TransferService>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values API V1");
    });
}


app.UseMiddleware<LogMiddleware>();

app.MapControllers();

app.Run();
