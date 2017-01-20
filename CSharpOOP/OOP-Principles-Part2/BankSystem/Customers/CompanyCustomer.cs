namespace BankSystem.Customers
{
    using System.Collections.Generic;

    using Interface;

    public class CompanyCustomer : Customer, ICustomer
    {
        

        public CompanyCustomer(string name)
            : base(name)
        {
            
        }

        
    }
}
