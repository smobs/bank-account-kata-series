﻿using System.IO;
using BankingKata;
using BankingKata.Printers;
using NSubstitute;
using NUnit.Framework;

namespace BankingKataTests.Printers
{
    [TestFixture]
    public class BalancePrintingTests
    {
        [Test]
        public void CallsToDepositAreDelegatedToInnerAccount()
        {
            var mockAccount = Substitute.For<IAccount>();
            var balancePrintingAccount = new BalancePrintingAccount(mockAccount, new StringWriter());

            var depositAmount = new Money(5m);
            balancePrintingAccount.Deposit(depositAmount);

            mockAccount.Received().Deposit(depositAmount);
        }

        [Test]
        public void CallsToWithdrawAreDelegatedToInnerAccount()
        {
            var mockAccount = Substitute.For<IAccount>();
            var balancePrintingAccount = new BalancePrintingAccount(mockAccount, new StringWriter());

            var withdrawAmount = new Money(5m);
            balancePrintingAccount.Withdraw(withdrawAmount);

            mockAccount.Received().Withdraw(withdrawAmount);
        }
    }
}
