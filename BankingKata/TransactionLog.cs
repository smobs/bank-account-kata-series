using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BankingKata
{
    public class TransactionLog : ILedger
    {
        private readonly ICollection<ILedgerEntry> _transactions = new List<ILedgerEntry>();

        public void Record(ILedgerEntry ledgerEntry)
        {
            _transactions.Add(ledgerEntry);
        }

        public Money Total()
        {
            Func<Money, ILedgerEntry, Money> totallingStepFunction = (balance, transaction) => transaction.ApplyTo(balance);
            return _transactions.Aggregate(new Money(0m), totallingStepFunction);
        }
    }

    public interface ILedger
    {
        void Record(ILedgerEntry ledgerEntry);
        Money Total();
    }
}