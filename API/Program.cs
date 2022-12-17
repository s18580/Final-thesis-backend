global using Serilog;
using Application;
using Microsoft.OpenApi.Models;
using Persistance;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.Seq("http://localhost:8081")
    .CreateLogger();

builder.Services.AddCors();
builder.Services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddApplicationLayer(builder.Configuration); // mapper and mediatR
builder.Services.AddPersistanceLayer(builder.Configuration); // auth scheme and services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
                {
                    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Description = "Authorization header schame (\"bearer {token}\")",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });

                    options.OperationFilter<SecurityRequirementsOperationFilter>();
                });

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

Log.Fatal("Starting the API");

app.Run();

Log.CloseAndFlush();