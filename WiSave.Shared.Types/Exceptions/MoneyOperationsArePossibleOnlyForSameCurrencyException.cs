namespace WiSave.Shared.Types.Exceptions;

public class MoneyOperationsArePossibleOnlyForSameCurrencyException : Exception
{
    public MoneyOperationsArePossibleOnlyForSameCurrencyException()
        : base("Money operations are only possible when both amounts use the same currency.")
    {
    }

    public MoneyOperationsArePossibleOnlyForSameCurrencyException(string message)
        : base(message)
    {
    }

    public MoneyOperationsArePossibleOnlyForSameCurrencyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}