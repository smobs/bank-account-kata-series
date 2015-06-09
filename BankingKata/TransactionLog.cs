using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BankingKata
{
    public class TransactionLog : ILedger
    {
        private readonly ICollection<Transaction> _transactions = new List<Transaction>();

        public void Record(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public Money Total()
        {
            return _transactions.Aggregate(new Money(0m), (balance, transaction) => transaction.ApplyTo(balance));
        }
    }


    interface ITransactionGobbler
    {
        void Consume(Money m);
        Money Total();
    }

    public interface ILedger
    {
        void Record(Transaction transaction);
        Money Total();
    }
}