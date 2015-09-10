namespace BankingKata
{
    public class ArrangedOverdraftCalculator : ITransactionVisitor<Money>
    {
        private readonly ITransactionVisitor<Money> _innerVisitor;
        private readonly Money _arrangedOverdraftLimit = new Money(-200m);

        public ArrangedOverdraftCalculator(ITransactionVisitor<Money> innerVisitor)
        {
            _innerVisitor = innerVisitor;
        }

        public Money Visit(ITransaction currentTransaction, Money balance)
        {
            var newBalance = _innerVisitor.Visit(currentTransaction, balance);

            if (newBalance < _arrangedOverdraftLimit && !(balance < _arrangedOverdraftLimit))
            {
                return newBalance - new Money(30m);
            }

            return newBalance;
        }
    }
}