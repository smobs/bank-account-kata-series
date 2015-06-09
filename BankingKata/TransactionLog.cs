namespace BankingKata
{
    public class TransactionLog : ILedger
    {
        public void Record(Transaction transaction)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ILedger
    {
        void Record(Transaction transaction);
    }
}