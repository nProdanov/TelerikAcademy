namespace BankSystem.Interface
{
    public interface IAccount : IDeposit
    {
        decimal Balance { get; }
        decimal MonthlyIntRate { get; }
        decimal CalculateInterest(int months);
    }
}
