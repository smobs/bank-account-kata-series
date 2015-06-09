namespace BankingKata
{
    public class Transaction
    {
        private readonly Money _amount;

        public Transaction(Money amount)
        {
            _amount = amount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as Transaction);
            return transaction != null && _amount.Equals(transaction._amount);
        }
    }
}