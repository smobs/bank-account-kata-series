using System;

namespace BankingKata
{
    public class Cheque : DebitEntry
    {
        private readonly int _chequeNumber;

        public Cheque(int chequeNumber, DateTime transactionDate, Money amount) : base(transactionDate, amount)
        {
            _chequeNumber = chequeNumber;
        }
    }
}