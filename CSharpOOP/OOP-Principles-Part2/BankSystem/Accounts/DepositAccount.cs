namespace BankSystem.Accounts
{
    using System;

    using Interface;

    public abstract class DepositAccount : Account, IDeposit, IAccount, IWithdraw
    {
        public DepositAccount(decimal intRate)
            : base(intRate)
        {
        }

        public void Withdraw(decimal withdrawValue)
        {
            var checkValue = this.Balance - withdrawValue;
            if (checkValue < 0)
            {
                throw new ArgumentException("There is not enough money in account");
            }

            this.balance = checkValue;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }

            return base.CalculateInterest(months);

        }
    }
}
