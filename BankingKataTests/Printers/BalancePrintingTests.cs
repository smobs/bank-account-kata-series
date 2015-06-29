using System.IO;
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

        [Test]
        public void CallsToCalculateBalanceAreDelegatedToInnerAccount()
        {
            var mockAccount = Substitute.For<IAccount>();
            var balancePrintingAccount = new BalancePrintingAccount(mockAccount, new StringWriter());

            balancePrintingAccount.CalculateBalance();

            mockAccount.Received().CalculateBalance();
        }

        [Test]
        public void ReturnsBalanceOfInnerAccount()
        {
            var expectedBalance = new Money(13m);
            var mockAccount = Substitute.For<IAccount>();
            mockAccount.CalculateBalance().Returns(expectedBalance);
            var balancePrintingAccount = new BalancePrintingAccount(mockAccount, new StringWriter());
           
            var actualBalance = balancePrintingAccount.CalculateBalance();

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }
    }
}
