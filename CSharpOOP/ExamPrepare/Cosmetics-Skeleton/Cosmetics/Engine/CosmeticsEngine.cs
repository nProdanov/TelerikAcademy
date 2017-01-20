namespace Cosmetics.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using Contracts;

    public sealed class CosmeticsEngine : IEngine
    {
        private const string InvalidGenderType = "Invalid gender type!";
        private const string InvalidUsageType = "Invalid usage type!";

        //private readonly ICosmeticsFactory cosmeticsFactory;
        private readonly IShoppingCart shoppingCart;
        private readonly IDictionary<string, ICategory> categories;
        private readonly IDictionary<string, IProduct> products;
        private IInputOutputProvider inputOutputProvider;
        private ICommandFactory commandFactory;
        private IProcessCommandHandler processHandler;

        public CosmeticsEngine(
            ICosmeticsFactory cosmeticsFactory, 
            IShoppingCart shoppingCart, 
            IInputOutputProvider inputOutputProvider,
            ICommandFactory commandFactory,
            IProcessCommandHandler processHandler)
        {
            //this.cosmeticsFactory = cosmeticsFactory;
            this.shoppingCart = shoppingCart;
            this.inputOutputProvider = inputOutputProvider;
            this.commandFactory = commandFactory;
            this.processHandler = processHandler;
            this.categories = new Dictionary<string, ICategory>();
            this.products = new Dictionary<string, IProduct>();
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = this.inputOutputProvider.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = this.commandFactory.CreateCommand(currentLine);
                commands.Add(currentCommand);

                currentLine = this.inputOutputProvider.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.processHandler.HandleProcess(command, this.shoppingCart, this.categories, this.products);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }

            this.inputOutputProvider.WriteLine(output.ToString());
        }
    }
}
