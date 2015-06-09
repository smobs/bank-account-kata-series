using BankingKata;
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
    }
}
