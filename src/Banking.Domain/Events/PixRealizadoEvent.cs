namespace Banking.Domain.Events;

public sealed class PixRealizadoEvent : IDomainEvent
{
    public Guid PixId { get; }
    public Guid ContaOrigemId { get; }
    public Guid ContaDestinoId { get; }
    public decimal Valor { get; }
    public DateTime OcorridoEm { get; }

    public PixRealizadoEvent(Guid contaOrigemId, Guid contaDestinoId, decimal valor)
    {
        PixId = Guid.NewGuid();
        ContaOrigemId = contaOrigemId;
        ContaDestinoId = contaDestinoId;
        Valor = valor;
        OcorridoEm = DateTime.UtcNow;
    }
}
