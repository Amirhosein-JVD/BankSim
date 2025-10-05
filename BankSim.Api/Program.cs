using BankSim.Api.Middlewares;
using BankSim.Domain.Account;
using BankSim.Domain.Services;
using BankSim.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Orleans.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BankSim;Trusted_Connection=True;TrustServerCertificate=True;";

using var connection = new SqlConnection(connectionString);
connection.Open();

DatabaseInitializer.EnsureTableIsCreated(connection);

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IStatementService, StatementService>();
//builder.Services.AddSingleton<IAccountStore, InMemoryAccountStore>();
builder.Services.AddSingleton<ITransferService, TransferService>();
builder.Services.AddSingleton<IAccountFactoryService, AccountFactoryService>();
builder.Services.AddSingleton<IAccountStore>(sp => new InSqlServerStore(connectionString));
builder.Services.AddControllers();

builder.Host.UseOrleansClient((context, client) =>
{
    client.UseLocalhostClustering();

    client.Configure<ClusterOptions>(configureOptions: option =>
    {
        option.ClusterId = "Banksim.OrleansHost";
        option.ServiceId = "Banksim.ServiceId";
    });
});

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
