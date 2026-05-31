namespace Banking.Domain.ValueObjects;

public sealed class Cpf
{
    public string Numero { get; }

    public Cpf(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            throw new ArgumentException("CPF é obrigatório.");

        if (numero.Length != 11)
            throw new ArgumentException("CPF deve ter 11 dígitos.");

        Numero = numero;
    }

    public override string ToString() => Numero;
}
