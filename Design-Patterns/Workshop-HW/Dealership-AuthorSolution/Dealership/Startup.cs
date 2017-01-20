using Dealership.Engine;
using Ninject;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new DealershipModule());

            IEngine dealershipEngine = kernel.Get<IEngine>();
            dealershipEngine.Start();
        }
    }
}
