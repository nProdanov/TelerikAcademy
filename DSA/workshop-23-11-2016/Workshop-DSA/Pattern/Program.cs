using System;
using System.Text;

namespace Pattern
{
    public class Program
    {
        public static void Main()
        {
            char[] pattern = new char[] { 'u', 'r', 'd' };
            string[] paths = new string[11];
            paths[0] = "";

            for (int i = 1; i < paths.Length; i++)
            {
                paths[i] = GenerateNext(paths[i - 1]);
            }

            var input = int.Parse(Console.ReadLine());
            Console.WriteLine(paths[input]);


        }

        public static string GenerateNext(string previous)
        {
            var result = new StringBuilder();
            result.Append(TurnRight(previous));
            result.Append('u');
            result.Append(previous);
            result.Append('r');
            result.Append(previous);
            result.Append('d');
            result.Append(Turnleft(previous));

            return result.ToString();
            // urd

            // rul -> rigth
            // u
            // urd -> up
            // r
            // urd -> up
            // d
            // ldr -> left
        }

        public static string TurnRight(string element)
        {
            var result = new StringBuilder();
            for (int i = element.Length - 1; i >= 0; i--)
            {
                switch (element[i])
                {
                    case 'd':
                        result.Append('r');
                        break;
                    case 'r':
                        result.Append('u');
                        break;
                    case 'u':
                        result.Append('l');
                        break;
                    case 'l':
                        result.Append('d');
                        break;
                }
            }

            return result.ToString();
        }

        public static string Turnleft(string element)
        {
            var result = new StringBuilder();
            for (int i = element.Length - 1; i >= 0; i--)
            {
                switch (element[i])
                {
                    case 'd':
                        result.Append('l');
                        break;
                    case 'r':
                        result.Append('d');
                        break;
                    case 'u':
                        result.Append('r');
                        break;
                    case 'l':
                        result.Append('u');
                        break;
                }
            }

            return result.ToString();
        }
    }
}
