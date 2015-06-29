using System;
using System.IO;

namespace BankingKata.Printers
{
    public class BalancePrintingAccount : IAccount
    {
        private readonly IAccount _account;
        private readonly TextWriter _printer;

        public BalancePrintingAccount(IAccount account, TextWriter printer)
        {
            if (account == null) throw new ArgumentNullException("account");
            if (printer == null) throw new ArgumentNullException("printer");

            _account = account;
            _printer = printer;
        }

        public void Deposit(Money amount)
        {
            _account.Deposit(amount);
        }

        public Money CalculateBalance()
        {
            return new Money(2m);
        }

        public void Withdraw(Money amount)
        {
            _account.Withdraw(amount);
        }
    }
}
