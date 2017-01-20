namespace VersionAttribute
{
    using System;
    using System.Reflection;

    [Version("TestAttribute", "1.16")]
    public class TestAttribute
    {
        public static void Main()
        {
            PrintVersion();
        }

        private static void PrintVersion()
        {
            var attributes = typeof(TestAttribute).GetCustomAttributes<VersionAttribute>();

            foreach (var attr in attributes)
            {
                Console.WriteLine("{0}     Version: {1}", attr.Name, attr.Version);
            }
        }
    }
}
