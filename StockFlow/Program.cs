using FluentValidation; // Install FluentValidation from NuGet Package
using Microsoft.EntityFrameworkCore; // Install this from NuGet Package
using Scalar.AspNetCore; // Install this from NuGet Package
using StockFlow.Data;
using StockFlow.Dtos.User;
using StockFlow.Services;
using Serilog;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

//Log.Logger = new LoggerConfiguration()
//    .Enrich.FromLogContext()
//    .Enrich.WithProperty("Application", "StockFlow")
//    .WriteTo.Console()
//    .WriteTo.Elasticsearch(
//        new ElasticsearchSinkOptions(
//            new Uri("http://localhost:9200")
//        )
//        {
//            AutoRegisterTemplate = true,
//            IndexFormat = "stockflow-logs-{0:yyyy.MM.dd}"
//        })
//    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidation>();
builder.Services.AddScoped<IUserService, UserService>();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Elasticsearch
dotnet add package Serilog.Sinks.Console

dotnet add package FluentValidation
dotnet add package FluentValidation.DependencyInjectionExtensions
 */
