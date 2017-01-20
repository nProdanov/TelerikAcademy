namespace BankSystem.Accounts
{
    using System;

    using Interface;

    public class IndividualMortgageAccount : CreditAccount, IDeposit, IAccount
    {
        public IndividualMortgageAccount(decimal intRate) 
            : base(intRate)
        {
        }

        public override void Borrow(decimal creditValue)
        {
            if (creditValue>100000)
            {
                throw new ArgumentOutOfRangeException("As individual customer maximal mortgage credit is 100 000lv");
            }

            base.Borrow(creditValue);
        }

        public override decimal CalculateInterest(int months)
        {
            if (months>0 && months<=6)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }
    }
}
