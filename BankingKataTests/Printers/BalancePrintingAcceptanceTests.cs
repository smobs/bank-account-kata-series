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
            var printer = new BalancePrintingAccount(new Account(), stringWriter);

            printer.Deposit(new Money(123m));
            printer.Deposit(new Money(234m));
            printer.Withdraw(new Money(12m));
            
            printer.CalculateBalance();

            Assert.That(stringWriter.ToString(), Is.EqualTo("Balance: £345.00"));
        }
    }
}
