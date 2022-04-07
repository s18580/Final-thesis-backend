using Application;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationLayer();
builder.Services.AddPersistanceLayer(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();