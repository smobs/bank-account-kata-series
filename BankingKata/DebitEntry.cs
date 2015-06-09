﻿namespace BankingKata
{
    public class DebitEntry : ILedgerEntry
    {
        private readonly Money _amount;

        public DebitEntry(Money amount)
        {
            _amount = amount;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - _amount;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as DebitEntry);
            return transaction != null && _amount.Equals(transaction._amount);
        }
    }
}