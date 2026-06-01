using Banking.Application.Interfaces;
using Banking.Application.Services;
using Banking.Domain.Interfaces;
using Banking.Infrastructure.Messaging;
using Banking.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking API", Version = "v1" });
});

builder.Services.AddScoped<PixService>();
builder.Services.AddScoped<IContaRepository, ContaRepositoryFake>();
builder.Services.AddScoped<IMessagePublisher, RabbitMqPublisher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking API v1");
        c.RoutePrefix = string.Empty; // serve Swagger UI at application's root
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
