using System;
class BankAccount
{
    static void Main()
    {
        //A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, 
        //IBAN, 3 credit card numbers associated with the account. Declare the variables needed to keep the information for a single 
        //bank account using the appropriate data types and descriptive names.

        string firstName = "Joro";
        string middleName = "Jorovov";
        string lastName = "Jorovovov";
        decimal balance = 123131.3123131321m;
        string bankName = "MustakBank";
        string iban = "BG2132313123123123123";
        long firstCreditCard = 2133987623457654;
        long secondCreditCard = 2133987623452345;
        long thirdCreditCard = 2133987653452345;

        Console.WriteLine("First Name: {0}",firstName);
        Console.WriteLine("Middle Name: {0}",middleName);
        Console.WriteLine("Last Name: {0}", lastName);
        Console.WriteLine("Amount of money (balance): {0}",balance);
        Console.WriteLine("Bank Name: {0}",bankName);
        Console.WriteLine("IBAN: {0}", iban);
        Console.WriteLine("Credit Card: {0}", firstCreditCard);
        Console.WriteLine("Credit Card: {0}", secondCreditCard);
        Console.WriteLine("Credit Card: {0}", thirdCreditCard);



    }
}

