using BankingKata;
using NSubstitute;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void AccountRecordsDepositInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            Account account = new Account(ledger);
            
            account.Deposit(money);

            Transaction deposit = new Transaction(money);
            ledger.Received().Record(deposit);
        }

        [Test]
        public void CalculateBalanceTotalsAllDepositsMadeToTheAccount()
        {
            var ledger = Substitute.For<ILedger>();
            var account = new Account(ledger);

            account.CalculateBalance();

            ledger.Received().Total();
        }

        [Test]
        public void LedgerTotalIsReturnedByCalculate()
        {
            var expectedBalance = new Money(13m);
            var ledger = Substitute.For<ILedger>();
            ledger.Total().Returns(expectedBalance);
            var account = new Account(ledger);

            var actualBalance = account.CalculateBalance();

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }

    }
}
