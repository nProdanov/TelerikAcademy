namespace Batman
{
    using System;

    public static class Printer
    {
        private static char charToPrintWith;
        private static int heigth;
        private static int width;

        static Printer()
        {
            heigth = int.Parse(Console.ReadLine());
            charToPrintWith = char.Parse(Console.ReadLine());
            width = heigth * 3;
        }

        public static void PrintBatman()
        {
            PrintFirstPart();

            PrintTheEarsRow();

            PrintSecondPart();

            PrintThirdPart();
        }

        private static void PrintFirstPart()
        {
            int numberOfCharsToPrint = heigth;
            int numberOfOutWhiteSpaces = 0;
            int numberOfInnerWhiteSpaces = heigth;
            int halfOfTheHeigth = heigth / 2;

            for (int i = 1; i < halfOfTheHeigth; i++)
            {
                PrintStringWithWhiteSpaces(numberOfOutWhiteSpaces);
                PrintStringWithChars(numberOfCharsToPrint);

                PrintStringWithWhiteSpaces(numberOfInnerWhiteSpaces);
                PrintStringWithCharsAndAppendLine(numberOfCharsToPrint);

                numberOfOutWhiteSpaces++;
                numberOfCharsToPrint--;
            }
        }

        private static void PrintTheEarsRow()
        {
            int numberOfOuterWhiteSpaces = (heigth / 2) - 1;
            int numberOfCharsToPrint = heigth - numberOfOuterWhiteSpaces;
            int numberOfInnerWhiteSpaces = (heigth - 3) / 2;

            PrintStringWithWhiteSpaces(numberOfOuterWhiteSpaces);
            PrintStringWithChars(numberOfCharsToPrint);

            PrintStringWithWhiteSpaces(numberOfInnerWhiteSpaces);
            Console.Write(charToPrintWith);
            Console.Write(' ');
            Console.Write(charToPrintWith);
            PrintStringWithWhiteSpaces(numberOfInnerWhiteSpaces);

            PrintStringWithCharsAndAppendLine(numberOfCharsToPrint);
        }

        private static void PrintSecondPart()
        {
            int numberOfCharsToPrint = (heigth * 2) + 1;
            int numberOfWhiteSpaces = (width - numberOfCharsToPrint) / 2;

            for (int i = 0; i < heigth / 3; i++)
            {
                PrintStringWithWhiteSpaces(numberOfWhiteSpaces);
                PrintStringWithCharsAndAppendLine(numberOfCharsToPrint);
            }
        }

        private static void PrintThirdPart()
        {
            int numberOfCharsToPrint = heigth - 2;
            int numberOfWhiteSpaces = (width - numberOfCharsToPrint) / 2;

            for (int i = numberOfCharsToPrint; i >= 0; i -= 2)
            {
                PrintStringWithWhiteSpaces(numberOfWhiteSpaces);
                PrintStringWithCharsAndAppendLine(numberOfCharsToPrint);

                numberOfCharsToPrint -= 2;
                numberOfWhiteSpaces++;
            }
        }

        private static void PrintStringWithWhiteSpaces(int numberOfWhiteSpaces)
        {
            Console.Write(new string(' ', numberOfWhiteSpaces));
        }

        private static void PrintStringWithCharsAndAppendLine(int numberOfChars)
        {
            Console.WriteLine(new string(Printer.charToPrintWith, numberOfChars));
        }

        private static void PrintStringWithChars(int numberOfChars)
        {
            Console.Write(new string(Printer.charToPrintWith, numberOfChars));
        }
    }
}
