using System.Configuration;
using JayrideChallenge.Services;
using JayrideChallenge.Utils;
using Microsoft.CodeAnalysis.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.Configure<ExternalServices>(builder.Configuration.GetSection("ExternalServices"));
var options = builder.Configuration.GetSection("ExternalServices").Get<ExternalServicesOptions>();
builder.Services.AddHttpClient<LocationService>((client) =>
{
    client.DefaultRequestHeaders.Add("Authorization", options.LocationApi.Token);
    client.BaseAddress = new Uri(options.LocationApi.BaseAddress);
});
builder.Services.AddHttpClient<PassengerService>((client) =>
{
    client.BaseAddress = new Uri(options.PassengerApi.BaseAddress);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

