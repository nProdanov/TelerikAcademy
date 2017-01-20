namespace Printers
{
    public class Printer
    {
        private const int MaxCount = 6;
        
        public static void PrintTrue()
        {
            var boolPrinter = new BoolPrinter();
            boolPrinter.Print(true);
        }
    }
}
