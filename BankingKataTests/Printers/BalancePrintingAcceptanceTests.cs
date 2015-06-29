using System;
using System.IO;
using BankingKata;
using BankingKata.Printers;
using NUnit.Framework;

namespace BankingKataTests.Printers
{
    [TestFixture]
    public class BalancePrintingAcceptanceTests
    {
        [Test]
        public void PositiveBalancesArePrinted()
        {
            var stringWriter = new StringWriter();
            var moneyFormatter = new MoneyFormatter();
            var printer = new MoneyPrinter(stringWriter, moneyFormatter);
            var account = new BalancePrintingAccount(new Account(), printer);

            account.Deposit(new Money(123m));
            account.Deposit(new Money(234m));
            account.Withdraw(new Money(12m));
            
            account.CalculateBalance();

            Assert.That(stringWriter.ToString(), Is.EqualTo("Balance: £345.00"));
        }
    }
}
