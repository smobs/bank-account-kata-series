﻿using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class TransactionLogTests
    {
        [Test]
        public void TotalIsInitiallyZero()
        {
            var actualTotal = new TransactionLog().Total();

            var expectedTotal = new Money(0m);
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void TotalEqualsSumOfAddedMoney()
        {
            var transactionLog = new TransactionLog();

            transactionLog.Record(new CreditEntry(new Money(1m)));
            transactionLog.Record(new CreditEntry(new Money(3m)));
            
            var actualTotal = transactionLog.Total();
            
            var expectedTotal = new Money(4m);
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }

        [Test]
        public void TheTotalALogWithOnlyDebitsIsTheirNegativeSum()
        {
            var transactionLog = new TransactionLog();

            transactionLog.Record(new DebitEntry(new Money(1m)));
            transactionLog.Record(new DebitEntry(new Money(3m)));

            var actualTotal = transactionLog.Total();

            var expectedTotal = new Money(-4m);
            Assert.That(actualTotal, Is.EqualTo(expectedTotal));
        }
    }
}
