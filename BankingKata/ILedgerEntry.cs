namespace BankingKata
{
    public interface ILedgerEntry
    {
        Money ApplyTo(Money balance);
    }
}