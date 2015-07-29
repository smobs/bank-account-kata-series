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

        public override string ToString()
        {
            return string.Format("{0} ({1})", transactionDate.ToString("dd MMM yy"), transactionAmount);
        }
    }
}