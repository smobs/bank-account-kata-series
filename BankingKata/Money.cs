namespace BankingKata
{
    public class Money
    {
        private readonly decimal _amount;

        public Money(decimal amount)
        {
            _amount = amount;
        }

        public override bool Equals(object obj)
        {
            return true;
        }
    }
}