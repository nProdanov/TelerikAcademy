namespace BankSystem.Accounts
{
    using Interface;

    public class CompanyDepositAccount : DepositAccount, IDeposit, IWithdraw, IAccount
    {
        public CompanyDepositAccount(decimal intRate) 
            : base(intRate)
        {
        }
    }
}
