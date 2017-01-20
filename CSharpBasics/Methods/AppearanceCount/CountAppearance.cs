using System;
class CountAppearance
{
    static int Appearance(int[] arr, int number)
    {
        int count = 0;
        for (int a = 0; a < arr.Length; a++)
        {
            if (arr[a] == number)
            {
                count++;
            }
        }
        return count;

    }



    static void Main()
    {
        Console.Write("enter some integer numebr separated by space: ");
        string text = Console.ReadLine();
        string[] numbersAsText = text.Split(new char[] { ' ', '.'},StringSplitOptions.RemoveEmptyEntries);
        int[] arr = new int[numbersAsText.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(numbersAsText[i]);
        }
        Console.Write("enter the number we are looking for:" );
        int number = int.Parse(Console.ReadLine());
        
        Console.WriteLine(Appearance(arr, number));
    }
}

