using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void TwoMoniesWithTheSameValueAreEqual()
        {
            const decimal amountOfMoney = 3m;
            var money1 = new Money(amountOfMoney);
            var money2 = new Money(amountOfMoney);
            Assert.That(money1,Is.EqualTo(money2));
        }
    }
}
