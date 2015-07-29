using System;

namespace BankingKata
{
    public class Cheque : DebitEntry
    {
        private readonly int _chequeNumber;

        public Cheque(int chequeNumber, DateTime transactionDate, Money transactionAmount) : base(transactionDate, transactionAmount)
        {
            _chequeNumber = chequeNumber;
        }

        public override string ToString()
        {
            return String.Format("CHQ {0} ", _chequeNumber) + base.ToString();
        }
    }
}