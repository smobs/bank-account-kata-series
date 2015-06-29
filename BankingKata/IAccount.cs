namespace BankingKata
{
    public interface IAccount
    {
        void Deposit(Money amount);
        Money CalculateBalance();
        void Withdraw(Money amount);
    }
}