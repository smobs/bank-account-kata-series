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
            var other = (Money) obj;
            return _amount == other._amount;
        }
    }
}