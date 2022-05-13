using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Common;
using TaxiDispatcher.DataInitialization;
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
    fv.RegisterValidatorsFromAssemblyContaining<OrderRideCommandValidator>();
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
app.Services.GetService<IInitializationDatabase>().InitData();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;

    if (exception.GetType().FullName != "FluentValidation.ValidationException")
    {
        var response = new ValidationException(Enums.ErrorCode.ErrUnknown.ToString());
        await context.Response.WriteAsJsonAsync(response);

    }
    else
    {
        var response = new ValidationException(exception.Message);
        await context.Response.WriteAsJsonAsync(response);

    }
}));

app.Run();

