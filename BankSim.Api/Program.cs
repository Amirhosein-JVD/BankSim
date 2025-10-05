using BankSim.Api.Middlewares;
using BankSim.Domain.Account;
using BankSim.Domain.Services;
using BankSim.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Orleans.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfiguration(new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build());

builder.Services.AddTransient<SqlConnectionStringBuilder>(_ =>
    new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("BankSimDb")));

builder.Services.AddSingleton<IStatementService, StatementService>();
builder.Services.AddSingleton<ITransferService, TransferService>();
builder.Services.AddSingleton<IAccountFactoryService, AccountFactoryService>();
builder.Services.AddSingleton<IAccountStore, InSqlServerStore>();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();


builder.Host.UseOrleansClient((_, client) =>
{
    var clusterId = builder.Configuration["Orleans:ClusterId"];
    var serviceId = builder.Configuration["Orleans:ServiceId"];

    client.UseLocalhostClustering();

    client.Configure<ClusterOptions>(configureOptions =>
    {
        configureOptions.ClusterId = clusterId;
        configureOptions.ServiceId = serviceId;
    });
});


var connectionString = builder.Configuration.GetConnectionString("BankSimDb");
var connection = new SqlConnection(connectionString);
DatabaseInitializer.EnsureTableIsCreated(connection);

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
