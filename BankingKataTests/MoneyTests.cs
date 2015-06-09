﻿using BankingKata;
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

        [Test]
        public void TwoMoniesWithDifferentValuesAreNotEqual()
        {
            Money money1 = new Money(3m);
            Money money2 = new Money(5m);

            Assert.That(money1, Is.Not.EqualTo(money2));
        }
    }
}
