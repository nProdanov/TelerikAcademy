using Cosmetics.Engine;
using Ninject;

namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new NinjectConfigModule());

            kernel.Get<CosmeticsEngine>().Start();
        }
    }
}
