using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using RESTSample.Infrastructure;
using RESTSample.Core.Interfaces;
using RESTSample.Core.Services;
using RESTSample.Repositories;
using RESTSample;
using DotNetEnv;

Env.Load();
var builder = WebApplication.CreateBuilder(args);
var appConfig = new RESTSample.Configurations.App
{
    URL = Environment.GetEnvironmentVariable("APP_HOST_PORT") ?? "http://localhost:8080",
    DBPostgres = new RESTSample.Configurations.DBPostgres
    {
        Host = Environment.GetEnvironmentVariable("DB_HOST") ?? "",
        Port = Environment.GetEnvironmentVariable("DB_PORT") ?? "",
        Username = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "",
        Password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "",
        DBName = Environment.GetEnvironmentVariable("DB_NAME") ?? "",
    }
};

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDeviceInteractionRepository, DeviceInteractionRepository>();
var dbConnectionString = string.Format("Host={0};Port={1};Username={2};Password={3};Database={4}",
    appConfig.DBPostgres.Host,
    appConfig.DBPostgres.Port,
    appConfig.DBPostgres.Username,
    appConfig.DBPostgres.Password,
    appConfig.DBPostgres.DBName
);
builder.Services.AddDbContext<DeviceInteractionContext>(
    options => options
    .UseNpgsql(dbConnectionString)
    .LogTo(Console.WriteLine, LogLevel.Debug)
);
builder.Services.AddScoped<IDeviceInteractionService, DeviceInteractionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(appConfig.URL);

