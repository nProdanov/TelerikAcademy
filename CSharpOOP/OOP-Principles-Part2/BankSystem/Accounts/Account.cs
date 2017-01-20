namespace BankSystem.Accounts
{
    using System;

    using Interface;

    public abstract class Account : IAccount, IDeposit
    {
       
        protected decimal balance;
        protected decimal intRate;

        public Account(decimal intRate)
        {
            this.balance = 0m;
            this.MonthlyIntRate = intRate;
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
        }

        public decimal MonthlyIntRate
        {
            get
            {
                return this.intRate;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate must be more than 0%");
                }

                this.intRate = value;
            }
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (months<1)
            {
                throw new ArgumentException("Month must be a positive value");
            }
            var interest = Math.Abs(this.Balance) * (this.MonthlyIntRate / 100) * months;
            return interest;
        }

        public void Deposit(decimal depositValue)
        {
            this.balance += depositValue;
        }
    }


}

