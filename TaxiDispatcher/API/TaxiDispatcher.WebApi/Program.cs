using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using System.Reflection;
using TaxiDispatcher.Application.Queries.Taxi;
using TaxiDispatcher.WebApi.Initialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


ConfigurationManager configuration = builder.Configuration;
Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
builder.Host.UseSerilog();



builder.Services.Initialize(configuration);


// Fluent validation
builder.Services.AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<GetTaxiByIdQueryValidator>();
    fv.ImplicitlyValidateRootCollectionElements = true;
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
Log.Information("TaxiDispatcher.WebApi Starting Up! {Environment}", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development");
app.Run();
