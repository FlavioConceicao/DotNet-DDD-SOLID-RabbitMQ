using Banking.Application.Interfaces;
using Banking.Application.Services;
using Banking.Domain.Interfaces;
using Banking.Infrastructure.Messaging;
using Banking.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PixService>();
builder.Services.AddScoped<IContaRepository, ContaRepositoryFake>();
builder.Services.AddScoped<IMessagePublisher, RabbitMqPublisher>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
