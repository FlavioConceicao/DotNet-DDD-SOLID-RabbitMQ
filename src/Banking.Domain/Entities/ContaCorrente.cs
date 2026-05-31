using Banking.Domain.Events;
using Banking.Domain.ValueObjects;

namespace Banking.Domain.Entities;

public sealed class ContaCorrente
{
    private readonly List<IDomainEvent> _events = new();

    public Guid Id { get; private set; }
    public Cpf CpfTitular { get; private set; }
    public Dinheiro Saldo { get; private set; }

    public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();

    public ContaCorrente(Guid id, Cpf cpfTitular, Dinheiro saldoInicial)
    {
        Id = id;
        CpfTitular = cpfTitular;
        Saldo = saldoInicial;
    }

    public void Debitar(Dinheiro valor)
    {
        Saldo -= valor;
    }

    public void Creditar(Dinheiro valor)
    {
        Saldo += valor;
    }

    public void TransferirPara(ContaCorrente destino, Dinheiro valor)
    {
        if (destino is null)
            throw new ArgumentNullException(nameof(destino));

        Debitar(valor);
        destino.Creditar(valor);

        _events.Add(new PixRealizadoEvent(Id, destino.Id, valor.Valor));
    }

    public void LimparEventos()
    {
        _events.Clear();
    }
}
