﻿using System;
class Employee
{
    static void Main()
    {
        //A marketing company wants to keep record of its employees. Each record would have the following characteristics:
        //
        //First name
        //Last name
        //Age (0...100)
        //Gender (m or f)
        //Personal ID number (e.g. 8306112507)
        //Unique employee number (27560000…27569999)
        //Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. Print the data at the console.

        string firstname = "Gosho";
        string lastName = "Peshov";
        byte age = 28;
        char gender = 'M';
        long idNumber = 8306112507;
        long uniqueEmployeeNumber = 27560001;
        Console.WriteLine(firstname);
        Console.WriteLine(lastName);
        Console.WriteLine(age);
        Console.WriteLine(gender);
        Console.WriteLine(idNumber);
        Console.WriteLine(uniqueEmployeeNumber);

    }
}

