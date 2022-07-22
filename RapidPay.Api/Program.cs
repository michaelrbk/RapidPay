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

builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer("01G8H2T5K78BYVEN8JFMN1NGZG");

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory(config.GetValue<string>("Database:ConnectionString")));
builder.Services.AddHostedService(sp => sp.GetRequiredService<UFEBackgroundService>());
builder.Services.AddSingleton<UFEBackgroundService>();
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<ICardRepository, CardRepository>();
builder.Services.AddSingleton<ICardService, CardService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();