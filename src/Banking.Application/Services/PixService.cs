using Banking.Application.Commands;
using Banking.Application.Interfaces;
using Banking.Domain.Interfaces;
using Banking.Domain.ValueObjects;

namespace Banking.Application.Services;

public sealed class PixService
{
    private readonly IContaRepository _contaRepository;
    private readonly IMessagePublisher _publisher;

    public PixService(
        IContaRepository contaRepository,
        IMessagePublisher publisher)
    {
        _contaRepository = contaRepository;
        _publisher = publisher;
    }

    public async Task RealizarPixAsync(RealizarPixCommand command)
    {
        var origem = await _contaRepository.ObterPorIdAsync(command.ContaOrigemId);
        var destino = await _contaRepository.ObterPorIdAsync(command.ContaDestinoId);

        if (origem is null)
            throw new InvalidOperationException("Conta de origem não encontrada.");

        if (destino is null)
            throw new InvalidOperationException("Conta de destino não encontrada.");

        origem.TransferirPara(destino, new Dinheiro(command.Valor));

        await _contaRepository.SalvarAsync(origem);
        await _contaRepository.SalvarAsync(destino);

        foreach (var evento in origem.Events)
        {
            await _publisher.PublishAsync(evento);
        }

        origem.LimparEventos();
    }
}
