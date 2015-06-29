using System;

namespace BankingKata.Printers
{
    public class BalancePrintingAccount : IAccount
    {
        private readonly IAccount _account;
        private readonly MoneyPrinter _printer;

        public BalancePrintingAccount(IAccount account, MoneyPrinter printer)
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
            _printer.Print(new Money(165m));
            return _account.CalculateBalance();
        }

        public void Withdraw(Money amount)
        {
            _account.Withdraw(amount);
        }
    }
}
