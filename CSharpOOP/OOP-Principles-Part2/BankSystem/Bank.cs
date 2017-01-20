namespace BankSystem
{
    using System.Collections.Generic;

    using Interface;

    public class Bank
    {
        public const decimal IndividualLoanMonthRate = 1.16m;
        public const decimal IndividualMortgageMonthRate = 0.62m;
        public const decimal IndividualDepositMonthRate = 0.7m;
        public const decimal CompanyLoanMonthRate = 0.95m;
        public const decimal CompanyMortgageMonthRate = 0.45m;
        public const decimal CompanyDepositMonthRate = 0.95m;

        List<ICustomer> customers;

        public Bank()
        {
            this.customers = new List<ICustomer>();
        }

        public IEnumerable<ICustomer> Customers
        {
            get
            {
                return this.customers;
            }
        }

        public void AddCustomer(ICustomer customer)
        {
            this.customers.Add(customer);
        }



    }
}
