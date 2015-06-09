using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountAcceptanceTests
    {
        [Test]
        public void DepositingCashIncreasesTheAccountBalance()
        {
            var account = new Account();
            
            account.Deposit(new Money(5.00m));
            
            Money expected = new Money(5.00m);
            Assert.That(account.CalculateBalance(), Is.EqualTo(expected));
        }
    }
}
