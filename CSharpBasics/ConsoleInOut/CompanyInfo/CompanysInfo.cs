using System;
class CompanysInfo
{
    static void Main()
    {
     //     Company name
     //Company address
     //Phone number
     //Fax number
     //Web site
     //Manager first name
     //Manager last name
     //Manager age
     //Manager phone

        string companyName = Console.ReadLine();
        string companyAddress = Console.ReadLine();
        string phoneNumber = Console.ReadLine();
        string faxNumber = Console.ReadLine();
        string webSite = Console.ReadLine();
        string managerFName = Console.ReadLine();
        string managerLName = Console.ReadLine();
        string managerAge = Console.ReadLine();
        string managerPhone = Console.ReadLine();

        Console.WriteLine(companyName);
        Console.WriteLine("Address: {0}",companyAddress);
        Console.WriteLine("Tel. {0}", phoneNumber);
        Console.Write("Fax: ");
        Console.WriteLine(faxNumber==""?"(no fax)":faxNumber );
        Console.WriteLine("Web site: {0}",webSite);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})",managerFName,managerLName, managerAge, managerPhone);

    }
}

