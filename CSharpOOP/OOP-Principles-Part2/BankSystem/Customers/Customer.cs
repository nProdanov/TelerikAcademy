namespace BankSystem.Customers
{
    using System;
    using System.Collections.Generic;

    using Interface;

    public abstract class Customer : ICustomer
    {
        private List<IAccount> accounts;
        protected string name;

        public Customer(string name)
        {
            this.Name = name;
            this.accounts = new List<IAccount>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name is empty!");
                }

                if (value.Length > 30)
                {
                    throw new ArgumentException("The name is too long");
                }

                this.name = value;
            }
        }

        public IEnumerable<IAccount> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        public void AddAccount(IAccount acc)
        {
            this.accounts.Add(acc);
        }
    }
}
