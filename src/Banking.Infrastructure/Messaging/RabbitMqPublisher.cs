using System.Text;
using System.Text.Json;
using Banking.Application.Interfaces;
using Banking.Domain.Events;
using RabbitMQ.Client;

namespace Banking.Infrastructure.Messaging;

public sealed class RabbitMqPublisher : IMessagePublisher
{
    public Task PublishAsync<TEvent>(TEvent domainEvent)
        where TEvent : IDomainEvent
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        const string exchangeName = "banking.events";

        channel.ExchangeDeclare(
            exchange: exchangeName,
            type: ExchangeType.Fanout,
            durable: true);

        var json = JsonSerializer.Serialize(domainEvent);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(
            exchange: exchangeName,
            routingKey: "",
            basicProperties: null,
            body: body);

        return Task.CompletedTask;
    }
}
