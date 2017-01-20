namespace BankSystem.Interface
{
    using System.Collections.Generic;
    
    public interface ICustomer
    {
        string Name { get; }
        IEnumerable<IAccount> Accounts { get; }
    }
}
