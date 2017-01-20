namespace BankSystem.Accounts
{
    using System;

    using Interface;

    public class CompanyLoanAccount : CreditAccount, IAccount, IDeposit
    {
        public CompanyLoanAccount(decimal intRate)
            : base(intRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months>0 && months<=2)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }

        public override void Borrow(decimal creditValue)
        {
            if (creditValue > 50000)
            {
                throw new ArgumentOutOfRangeException("The maximal loan for Company customers is 50 000lv.");
            }
            base.Borrow(creditValue);
        }
    }
}
