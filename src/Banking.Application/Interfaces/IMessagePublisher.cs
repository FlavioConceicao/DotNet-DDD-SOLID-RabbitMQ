using Banking.Domain.Events;

namespace Banking.Application.Interfaces;

public interface IMessagePublisher
{
    Task PublishAsync<TEvent>(TEvent domainEvent)
        where TEvent : IDomainEvent;
}
