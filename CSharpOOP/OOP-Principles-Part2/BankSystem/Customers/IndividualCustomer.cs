namespace BankSystem.Customers
{
    using Interface;

    public class IndividualCustomer : Customer, ICustomer
    { 

        public IndividualCustomer(string name)
            : base(name)
        {
            
        }

    }
}
