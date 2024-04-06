using ExamBreaker.API;
using ExamBreaker.Application;
using ExamBreaker.Infrastructure;
using ExamBreaker.Infrastructure.Persistence;
using FastEndpoints;
using FastEndpoints.Swagger;


var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterWebApiServices();
builder.Services.RegisterApplicationServices();
builder.Services.RegisterInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.Run();
