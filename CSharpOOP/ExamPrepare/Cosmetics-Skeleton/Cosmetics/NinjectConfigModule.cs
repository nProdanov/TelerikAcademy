using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System.IO;
using System.Reflection;
using Cosmetics.Contracts;
using Ninject.Extensions.Factory;
using Cosmetics.Engine;
using Cosmetics.Handlers;
using Ninject;

namespace Cosmetics
{
    public class NinjectConfigModule : NinjectModule
    {
        private const string ConsoleInputAoutProviderName = "ConsoleInputAoutProvider";

        private const string CreateCategoryHandlerName = "CreateCategoryHandler";
        private const string AddToShoppingCartHandlerName = "AddToShoppingCartHandler";
        private const string RemoveFromCategoryHandlerName = "RemoveFromCategoryHandler";
        private const string ShowCategoryHandlerName = "ShowCategoryHandler";
        private const string CreateShampooHandlerName = "CreateShampooHandler";
        private const string CreateToothpasteHandlerName = "CreateToothpasteHandler";
        private const string AddToCategoryHandlerName = "AddToCategoryHandler";
        private const string RemoveFromShoppingCartHandlerName = "RemoveFromShoppingCartHandler";
        private const string TotalPriceHandlerName = "TotalPriceHandler";

        public override void Load()
        {
            Kernel.Bind(x => 
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            Bind<ICosmeticsFactory>().ToFactory();
            Bind<ICommandFactory>().ToFactory();

            Bind<IInputOutputProvider>().To<ConsoleInputOutPutProvider>().WhenInjectedInto<CosmeticsEngine>().Named(ConsoleInputAoutProviderName);

            Bind<IProcessCommandHandler>().To<CreateCategoryHandler>().Named(CreateCategoryHandlerName);
            Bind<IProcessCommandHandler>().To<AddToShoppingCartHandler>().Named(AddToShoppingCartHandlerName);
            Bind<IProcessCommandHandler>().To<RemoveFromCategoryHandler>().Named(RemoveFromCategoryHandlerName);
            Bind<IProcessCommandHandler>().To<ShowCategoryHandler>().Named(ShowCategoryHandlerName);
            Bind<IProcessCommandHandler>().To<CreateShampooHandler>().Named(CreateShampooHandlerName);
            Bind<IProcessCommandHandler>().To<CreateToothpasteHandler>().Named(CreateToothpasteHandlerName);
            Bind<IProcessCommandHandler>().To<AddToCategoryHandler>().Named(AddToCategoryHandlerName);
            Bind<IProcessCommandHandler>().To<RemoveFromShoppingCartHandler>().Named(RemoveFromShoppingCartHandlerName);
            Bind<IProcessCommandHandler>().To<TotalPriceHandler>().Named(TotalPriceHandlerName);

            Bind<IProcessCommandHandler>()
                .ToMethod(context =>
                {
                    IProcessCommandHandler createToCategoryHandler = context.Kernel.Get<IProcessCommandHandler>(CreateCategoryHandlerName);
                    IProcessCommandHandler addToShoppingCartHandler = context.Kernel.Get<IProcessCommandHandler>(AddToShoppingCartHandlerName);
                    IProcessCommandHandler removeFromCategoryHandler = context.Kernel.Get<IProcessCommandHandler>(RemoveFromCategoryHandlerName);
                    IProcessCommandHandler showCategoryHandler = context.Kernel.Get<IProcessCommandHandler>(ShowCategoryHandlerName);
                    IProcessCommandHandler createShampooHandler = context.Kernel.Get<IProcessCommandHandler>(CreateShampooHandlerName);
                    IProcessCommandHandler createToothpasteHandler = context.Kernel.Get<IProcessCommandHandler>(CreateToothpasteHandlerName);
                    IProcessCommandHandler addToCategoryHandler = context.Kernel.Get<IProcessCommandHandler>(AddToCategoryHandlerName);
                    IProcessCommandHandler removeFromShoppingCartHandler = context.Kernel.Get<IProcessCommandHandler>(RemoveFromShoppingCartHandlerName);
                    IProcessCommandHandler totalPriceHandler = context.Kernel.Get<IProcessCommandHandler>(TotalPriceHandlerName);

                    createToCategoryHandler.SetSuccessor(addToShoppingCartHandler);
                    addToShoppingCartHandler.SetSuccessor(removeFromCategoryHandler);
                    removeFromCategoryHandler.SetSuccessor(showCategoryHandler);
                    showCategoryHandler.SetSuccessor(createShampooHandler);
                    createShampooHandler.SetSuccessor(createToothpasteHandler);
                    createToothpasteHandler.SetSuccessor(addToCategoryHandler);
                    addToCategoryHandler.SetSuccessor(removeFromShoppingCartHandler);
                    removeFromShoppingCartHandler.SetSuccessor(totalPriceHandler);

                    return createToCategoryHandler;
                }).WhenInjectedInto<CosmeticsEngine>();
        }
    }
}
