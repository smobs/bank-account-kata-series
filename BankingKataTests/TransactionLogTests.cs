﻿using BankingKata;
using NUnit.Framework;
using System;

namespace BankingKataTests
{
    [TestFixture]
    public class TransactionLogTests
    {
        [Test]
        public void TotalIsInitiallyZero()
        {
            var actualTotal = new Ledger().Accept(new BalanceCalculatingVisitor(), new Money(0m));

            var expectedTotal = new Money(0m);
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void TotalEqualsSumOfAddedMoney()
        {
            var transactionLog = new Ledger();

            transactionLog.Record(new CreditEntry(DateTime.Now, new Money(1m)));
            transactionLog.Record(new CreditEntry(DateTime.Now, new Money(3m)));

            var actualTotal = transactionLog.Accept(new BalanceCalculatingVisitor(), new Money(0m));

            var expectedTotal = new Money(4m);
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void TheTotalALogWithOnlyDebitsIsTheirNegativeSum()
        {
            var transactionLog = new Ledger();

            transactionLog.Record(new CashWithdrawal(DateTime.Now, new Money(1m)));
            transactionLog.Record(new CashWithdrawal(DateTime.Now, new Money(3m)));

            var actualTotal = transactionLog.Accept(new BalanceCalculatingVisitor(), new Money(0m));

            var expectedTotal = new Money(-4m);
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }
    }
}
