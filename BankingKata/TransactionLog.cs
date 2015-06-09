namespace BankingKata
{
    public class TransactionLog : ILedger
    {
        public void Record(Transaction transaction)
        {

        }

        public Money Total()
        {
            return new Money(0m);
        }
    }

    public interface ILedger
    {
        void Record(Transaction transaction);
        Money Total();
    }
}