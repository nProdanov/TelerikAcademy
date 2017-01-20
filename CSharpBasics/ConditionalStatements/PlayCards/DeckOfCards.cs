using System;
class DeckOfCards
{
    static void Main()
    {
        //Classical play cards use the following signs to designate the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A.
        //Write a program that enters a string and prints "yes CONTENT_OF_STRING" if it is a valid card sign or "no CONTENT_OF_STRING" 
        //otherwise.

        string usersString = Console.ReadLine();
        if (usersString=="J"||usersString=="Q"||usersString=="K"||usersString=="A"||usersString=="2"||usersString=="3"||usersString=="4"||
            usersString=="5"||usersString=="6"||usersString=="7"||usersString=="8"||usersString=="9"||usersString=="10")
        {
            Console.WriteLine("yes {0}",usersString );
        }
        else
        {
            Console.WriteLine("no {0}",usersString);
        }
    }
}

