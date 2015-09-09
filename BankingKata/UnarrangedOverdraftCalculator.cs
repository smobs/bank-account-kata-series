namespace BankingKata
{
    public class UnarrangedOverdraftCalculator : ITransactionVisitor<Money>
    {
        private readonly ITransactionVisitor<Money> _innerVisitor;
        private readonly Money _overdraftLimit = new Money(-1000);

        public UnarrangedOverdraftCalculator(ITransactionVisitor<Money> innerVisitor)
        {
            _innerVisitor = innerVisitor;
        }

        public Money Visit(ITransaction currentTransaction, Money balance)
        {
            var newBalance = _innerVisitor.Visit(currentTransaction, balance);
            if (newBalance < _overdraftLimit)
            {
                return balance;
            }
            return newBalance;
        }
    }
}