namespace BankSystem.Accounts
{
    using System;

    using Interface;

    public class CompanyMortgageAccount : CreditAccount, IDeposit, IAccount
    {
        public CompanyMortgageAccount(decimal intRate)
            : base(intRate)
        {
        }

        public override void Borrow(decimal creditValue)
        {
            if (creditValue > 500000)
            {
                throw new ArgumentOutOfRangeException("The maximal mortgage credit as company is 500 000lv.");
            }

            base.Borrow(creditValue);
        }

        public override decimal CalculateInterest(int months)
        {
            if (months>0 && months<=12)
            {
                return base.CalculateInterest(months) / 2;
            }
            return base.CalculateInterest(months);
        }
    }
}
