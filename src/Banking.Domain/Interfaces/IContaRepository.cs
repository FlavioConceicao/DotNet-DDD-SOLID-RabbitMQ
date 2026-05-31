using Banking.Domain.Entities;

namespace Banking.Domain.Interfaces;

public interface IContaRepository
{
    Task<ContaCorrente?> ObterPorIdAsync(Guid id);
    Task SalvarAsync(ContaCorrente conta);
}
