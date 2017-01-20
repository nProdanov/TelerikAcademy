namespace CustomException
{
    using System;

    public class ExceptionTest
    {
        public static void Main()
        {
            // Test int
            try
            {
                throw new InvalidRangeException<int>("Not in Range!", 2, 10);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);    
            }

            // Test DateTime
            try
            {
                throw new InvalidRangeException<DateTime>("Date is not valid!", new DateTime(1990, 08, 08), DateTime.Now);
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
                
            }

        }
    }
}
