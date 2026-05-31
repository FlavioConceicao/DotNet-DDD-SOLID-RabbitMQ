namespace Banking.Domain.ValueObjects;

public sealed class Dinheiro
{
    public decimal Valor { get; }

    public Dinheiro(decimal valor)
    {
        if (valor < 0)
            throw new ArgumentException("Valor não pode ser negativo.");

        Valor = valor;
    }

    public static Dinheiro operator +(Dinheiro a, Dinheiro b)
        => new(a.Valor + b.Valor);

    public static Dinheiro operator -(Dinheiro a, Dinheiro b)
    {
        if (a.Valor < b.Valor)
            throw new InvalidOperationException("Saldo insuficiente.");

        return new Dinheiro(a.Valor - b.Valor);
    }
}
