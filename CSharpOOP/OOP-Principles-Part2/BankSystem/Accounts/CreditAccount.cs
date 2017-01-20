namespace BankSystem.Accounts
{
    using System;

    using Interface;

    public abstract class CreditAccount : Account, IDeposit, IAccount
    {
        public CreditAccount(decimal intRate) 
            : base(intRate)
        {
        }

        public virtual void Borrow(decimal creditValue)
        {
            this.balance -= creditValue;
        }
    }
}
