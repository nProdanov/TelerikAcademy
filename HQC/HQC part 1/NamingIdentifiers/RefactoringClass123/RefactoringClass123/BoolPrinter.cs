namespace Printers
{
    using System;

    public class BoolPrinter
    {
        public void Print(bool booleanState)
        {
            string strBool = booleanState.ToString();
            Console.WriteLine(strBool);
        }
    }
}
