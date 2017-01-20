namespace MathOperations
{
    public class StartComparing
    {
        public static void Main(string[] args)
        {
            var factory = new OperationFactory();
            var engine = new ComparingEngine(factory);
            System.Console.WriteLine(engine.CompareReport());
        }
    }
}
