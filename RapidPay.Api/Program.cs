using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RapidPay.Api.Database;
using RapidPay.Api.Repositories;
using RapidPay.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services
    .AddAuthenticationJwtBearer(options => options.SigningKey = "9C5FE0ED928BA25C2D1CDD14071393BB8494DD9F")
    .AddAuthorization()
    .AddFastEndpoints();

builder.Services.AddSingleton<IDbConnectionFactory>(_ => new SqliteConnectionFactory(config.GetValue<string>("Database:ConnectionString")));
builder.Services.AddHostedService(sp => sp.GetRequiredService<UFEBackgroundService>());
builder.Services.AddSingleton<UFEBackgroundService>();
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<ICardRepository, CardRepository>();
builder.Services.AddSingleton<ICardService, CardService>();

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();