using System;

namespace BankingKata
{
    public class CashWithdrawal : DebitEntry
    {
        public CashWithdrawal(DateTime transactionDate, Money transactionAmount) : base(transactionDate, transactionAmount)
        {
        }

        public override string ToString()
        {
            return "ATM " + base.ToString();
        }
    }
}