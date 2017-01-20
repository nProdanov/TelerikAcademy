namespace BankSystem.Accounts
{
    using Interface;

    public class IndividualDepositAccount : DepositAccount, IDeposit, IWithdraw, IAccount
    {
        public IndividualDepositAccount(decimal intRate)
            : base(intRate)
        {
        }
    }
}
