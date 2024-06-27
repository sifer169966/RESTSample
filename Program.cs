using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using RESTSample.Infrastructure;
using EntityFramework.Exceptions.PostgreSQL;
using RESTSample.Core.Interfaces;
using RESTSample.Core.Services;
using RESTSample.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDeviceInteractionRepository, DeviceInteractionRepository>();
builder.Services.AddDbContext<DeviceInteractionContext>(
    options => options
    .UseNpgsql("Host=localhost;Port=5432;Username=local;Password=localonly;Database=device_interactions")
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

app.Run();

