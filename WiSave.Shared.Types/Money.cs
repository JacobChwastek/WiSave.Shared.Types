using WiSave.Shared.Types.Exceptions;

namespace WiSave.Shared.Types;

public record Money
{
    public Money()
    {
    }

    public Money(decimal amount, Currency currency)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be negative.");
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; init; }
    public Currency Currency { get; init; }

    public static Money operator *(Money money, uint times)
    {
        return money with { Amount = money.Amount * times };
    }

    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new MoneyOperationsArePossibleOnlyForSameCurrencyException();
        }

        return left with { Amount = left.Amount + right.Amount };
    }
}