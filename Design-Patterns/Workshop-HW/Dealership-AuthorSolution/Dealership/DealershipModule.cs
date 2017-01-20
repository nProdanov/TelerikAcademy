using System.IO;
using System.Reflection;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using Dealership.Engine;
using Dealership.Factories;
using Dealership.Contracts;
using Dealership.Models;
using Dealership.Handlers;

namespace Dealership
{
    public class DealershipModule : NinjectModule
    {
        private const string ConsoleReader = "ConsoleReader";
        private const string ConsoleLogger = "ConsoleLogger";

        private const string CarName = "Car";
        private const string MotorcycleName = "Motorcycle";
        private const string TruckName = "Truck";

        private const string CarHandlerName = "CarHandler";
        private const string TruckHandlerName = "TruckHandler";
        private const string MotorcycleHandlerName = "MotorcycleHandler";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .SelectAllClasses()
                    .BindDefaultInterface();
            });

            Bind<IEngine>().To<DealershipEngine>().InSingletonScope();

            Bind<IVehicleFactory>().ToFactory().InSingletonScope();
            Bind<ICommandFactory>().ToFactory().InSingletonScope();
            Bind<IUserFactory>().ToFactory().InSingletonScope();
            Bind<ICommentFactory>().ToFactory().InSingletonScope();

            Bind<IVehicle>().To<Car>().Named(CarName);
            Bind<IVehicle>().To<Truck>().Named(TruckName);
            Bind<IVehicle>().To<Motorcycle>().Named(MotorcycleName);

            Bind<Reader.IReader>().To<Reader.ConsoleReader>().Named(ConsoleReader);
            Bind<Logger.ILogger>().To<Logger.ConsoleLogger>().Named(ConsoleLogger);

            Bind<IVehicleHandler>().To<CarHandler>().Named(CarHandlerName);
            Bind<IVehicleHandler>().To<TruckHandler>().Named(TruckHandlerName);
            Bind<IVehicleHandler>().To<MotorcycleHandler>().Named(MotorcycleHandlerName);

            Bind<IVehicleHandler>().ToMethod(context =>
            {
                IVehicleHandler carHandler = context.Kernel.Get<IVehicleHandler>(CarHandlerName);
                IVehicleHandler truckHandler = context.Kernel.Get<IVehicleHandler>(TruckHandlerName);
                IVehicleHandler motorcycleHandler = context.Kernel.Get<IVehicleHandler>(MotorcycleHandlerName);

                carHandler.SetSuccesor(truckHandler);
                truckHandler.SetSuccesor(motorcycleHandler);

                return carHandler;
            }).WhenInjectedInto<DealershipEngine>();

        }
    }
}
