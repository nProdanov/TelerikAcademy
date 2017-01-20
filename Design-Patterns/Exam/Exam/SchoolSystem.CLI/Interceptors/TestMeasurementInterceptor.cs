using System;

using Ninject.Extensions.Interception;

using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Cli.Interceptors
{
    public class TestMeasurementInterceptor : IInterceptor
    {
        private IWriter writer;

        public TestMeasurementInterceptor(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            this.writer.WriteLine($"Calling method {invocation.Request.Method.Name} of type {invocation.Request.Method.DeclaringType.Name}...");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            invocation.Proceed();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Total execution time for method {invocation.Request.Method.Name} of type {invocation.Request.Method.DeclaringType.Name} is {elapsedMs} milliseconds.");
        }
    }
}
