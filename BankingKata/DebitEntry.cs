using System;

namespace BankingKata
{
    public abstract class DebitEntry : ITransaction
    {
        private readonly DateTime transactionDate;
        private readonly Money transactionAmount;

        protected DebitEntry(DateTime transactionDate, Money transactionAmount)
        {
            this.transactionDate = transactionDate;
            this.transactionAmount = transactionAmount;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - transactionAmount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as DebitEntry);
            return transaction != null && transactionAmount.Equals(transaction.transactionAmount);
        }
    }
}