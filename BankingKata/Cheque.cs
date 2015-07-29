using System;

namespace BankingKata
{
    public class Cheque : DebitEntry
    {
        private readonly string _transactionFormatString;

        public Cheque(int chequeNumber, DateTime transactionDate, Money transactionAmount) : base(transactionDate, transactionAmount)
        {
            _transactionFormatString = string.Format("CHQ {0} {1} ({2})", chequeNumber, transactionDate.ToString("dd MMM yy"), transactionAmount);
        }

        public override string ToString()
        {
            return _transactionFormatString;
        }
    }
}