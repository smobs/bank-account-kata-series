namespace BankingKata
{
    public class Money
    {
        private readonly decimal _amount;

        public Money(decimal amount)
        {
            _amount = amount;
        }

        public override bool Equals(object @object)
        {
            var other = @object as Money;
            return other != null && _amount == other._amount;
        }
    }
}