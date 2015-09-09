using System;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class BalanceCalculationTests
    {
        private static readonly Money OverdraftLimit = new Money(1000m);

        [Test]
        public void TransactionsExceedingTheOverdraftLimitHaveNoEffectOnTheBalance()
        {
            var newBalance = CalculateBalanceWith(AWithdrawlOf(OverdraftLimit + new Money(1m)));

            Assert.That(newBalance, Is.EqualTo(new Money(0m)));
        }

        [Test]
        public void DepositingAfterTryingToExceedTheOverdraftStillRecordsTheDeposit()
        {
            var depositAmount = new Money(50m);
            var newBalance = CalculateBalanceWith(
                AWithdrawlOf(OverdraftLimit + new Money(1m)),
                ADepositOf(depositAmount));
            
            Assert.That(newBalance, Is.EqualTo(depositAmount));
        }

        [Test]
        public void CanWithdrawUpToOverdraftLimit()
        {
            var newBalance = CalculateBalanceWith(AWithdrawlOf(OverdraftLimit));
            Assert.That(newBalance, Is.EqualTo(new Money(0m) - OverdraftLimit));
        }

        private static DebitEntry AWithdrawlOf(Money transactionAmount)
        {
            return new ATMDebitEntry(DateTime.Now, transactionAmount);
        }

        private static CreditEntry ADepositOf(Money transactionAmount)
        {
            return new CreditEntry(DateTime.Now, transactionAmount);
        }

        private static Money CalculateBalanceWith(params ITransaction[] debits)
        {
            var calculator = new UnarrangedOverdraftCalculator(new BalanceCalculatingVisitor());
            var ledger = new Ledger();

            foreach (var debitEntry in debits)
            {
                ledger.Record(debitEntry);
            }

            var newBalance = ledger.Accept(calculator, new Money(0m));
            return newBalance;
        }
    }
}