namespace Banking.Application.Commands;

public sealed class RealizarPixCommand
{
    public Guid ContaOrigemId { get; set; }
    public Guid ContaDestinoId { get; set; }
    public decimal Valor { get; set; }
}
