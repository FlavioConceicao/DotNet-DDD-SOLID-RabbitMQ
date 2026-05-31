using Banking.Domain.Entities;
using Banking.Domain.Interfaces;
using Banking.Domain.ValueObjects;

namespace Banking.Infrastructure.Repositories;

public sealed class ContaRepositoryFake : IContaRepository
{
    private static readonly Dictionary<Guid, ContaCorrente> _contas = new();

    static ContaRepositoryFake()
    {
        var conta1 = new ContaCorrente(
            Guid.Parse("11111111-1111-1111-1111-111111111111"),
            new Cpf("12345678901"),
            new Dinheiro(1000));

        var conta2 = new ContaCorrente(
            Guid.Parse("22222222-2222-2222-2222-222222222222"),
            new Cpf("98765432100"),
            new Dinheiro(500));

        _contas[conta1.Id] = conta1;
        _contas[conta2.Id] = conta2;
    }

    public Task<ContaCorrente?> ObterPorIdAsync(Guid id)
    {
        _contas.TryGetValue(id, out var conta);
        return Task.FromResult(conta);
    }

    public Task SalvarAsync(ContaCorrente conta)
    {
        _contas[conta.Id] = conta;
        return Task.CompletedTask;
    }
}
