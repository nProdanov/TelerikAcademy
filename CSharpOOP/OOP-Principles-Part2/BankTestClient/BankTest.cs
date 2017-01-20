namespace BankTestClient
{
    using BankSystem;
    using BankSystem.Accounts;
    using BankSystem.Customers;

    public class BankTest
    {
        public static void Main()
        {
            var testBank = new Bank();

            var vanio = new IndividualCustomer("Ivan Ivanov");

            var vanioLoan = new IndividualLoanAccount(Bank.IndividualLoanMonthRate);
            vanioLoan.Borrow(5000);

            var vanioDeposit = new IndividualDepositAccount(Bank.IndividualDepositMonthRate);
            vanioDeposit.Deposit(3000);

            vanio.AddAccount(vanioLoan);
            vanio.AddAccount(vanioDeposit);

            var pepiAD = new CompanyCustomer("Petar2000EOOD");

            var pepiDeposit = new CompanyDepositAccount(Bank.CompanyDepositMonthRate);
            pepiDeposit.Deposit(5000);
            pepiDeposit.Withdraw(2000);

            var pepiMortgage = new CompanyMortgageAccount(Bank.CompanyMortgageMonthRate);
            pepiMortgage.Borrow(100000);

            pepiAD.AddAccount(pepiDeposit);
            pepiAD.AddAccount(pepiMortgage);

            testBank.AddCustomer(vanio);
            testBank.AddCustomer(pepiAD);

            
            foreach (var cust in testBank.Customers)
            {
                System.Console.WriteLine(string.Format("Bank Accounts of {0} :", cust.Name));
                foreach (var acc in cust.Accounts)
                {
                    System.Console.WriteLine(string.Format("Type of account: {0}\r\nBalance:{1}\tInterest for 24 months: {2}", acc.GetType().Name, acc.Balance, acc.CalculateInterest(24)));
                }
                System.Console.WriteLine(new string('-', 25));
            }
        }
    }
}
