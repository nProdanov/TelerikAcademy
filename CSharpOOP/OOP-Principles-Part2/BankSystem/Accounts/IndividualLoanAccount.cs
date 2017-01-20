namespace BankSystem.Accounts
{
    using System;

    using Interface;

    public class IndividualLoanAccount : CreditAccount, IAccount, IDeposit
    {
        public IndividualLoanAccount(decimal intRate)
            : base(intRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months>0 &&months<=3)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }

        public override void Borrow(decimal creditValue)
        {
            if (creditValue >10000)
            {
                throw new ArgumentOutOfRangeException("As Individual customer the max loan is 10 000lv.");
            }
            base.Borrow(creditValue);
        }
    }
}
