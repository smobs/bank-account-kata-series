using System;

namespace BankingKata
{
    public class CashWithdrawal : DebitEntry
    {
        private readonly string _transactionFormatString;

        public CashWithdrawal(DateTime transactionDate, Money transactionAmount) : base(transactionDate, transactionAmount)
        {
            _transactionFormatString = string.Format("ATM {0} ({1})", transactionDate.ToString("dd MMM yy"), transactionAmount);
        }

        public override string ToString()
        {
            return _transactionFormatString;
        }
    }
}