namespace BankingKata
{
    public class Account : IAccount
    {
        private readonly ILedger _transactionLog;

        public Account(ILedger transactionLog)
        {
            _transactionLog = transactionLog;
        }

        public Account() : this(new Ledger())
        {
        }

        public void Deposit(Money amount)
        {
            var depositTransaction = new CreditEntry(amount);
            _transactionLog.Record(depositTransaction);
        }

        public Money CalculateBalance()
        {
            return _transactionLog.Accept(new BalanceCalculatingVisitor(), new Money(0m));
        }

        public void Withdraw(Money amount)
        {
            var debitEntry = new DebitEntry(amount);
            _transactionLog.Record(debitEntry);
        }
    }
}