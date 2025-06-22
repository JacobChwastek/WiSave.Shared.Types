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

    public static Money Zero(Currency currency) => new(0m, currency);
    
    public static Money operator *(Money money, uint times) => money with { Amount = money.Amount * times };

    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new MoneyOperationsArePossibleOnlyForSameCurrencyException();
        }

        return left with { Amount = left.Amount + right.Amount };
    }
    
    
    public static Money operator /(Money money, decimal divisor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(divisor);

        return new Money(money.Amount / divisor, money.Currency);
    }

    public static Money operator *(Money money, decimal multiplier)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(multiplier);

        return new Money(money.Amount * multiplier, money.Currency);
    }
    
    public static bool operator >(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new MoneyOperationsArePossibleOnlyForSameCurrencyException();
    
        return left.Amount > right.Amount;
    }

    public static bool operator <(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new MoneyOperationsArePossibleOnlyForSameCurrencyException();
    
        return left.Amount < right.Amount;
    }
}