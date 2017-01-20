namespace Bunnies
{
    using System.Collections.Generic;

    using Bunnies.Contracts;
    using Bunnies.Models;
    using Bunnies.Types;

    public class StartPoint
    {
        public static void Main(string[] args)
        {
            var bunnies = new List<IBunny>
                {
                    new Bunny { Name = "Leonid", Age = 1, FurType = FurType.NotFluffy },
                    new Bunny { Age = 2, Name = "Rasputin", FurType = FurType.ALittleFluffy },
                    new Bunny { Name = "Tiberii", Age = 3, FurType = FurType.ALittleFluffy },
                    new Bunny { Name = "Neron", Age = 1, FurType = FurType.ALittleFluffy },
                    new Bunny { Name = "Klavdii", Age = 3, FurType = FurType.Fluffy },
                    new Bunny { Name = "Vespasian", Age = 3, FurType = FurType.Fluffy },
                    new Bunny { Name = "Domician", Age = 4, FurType = FurType.FluffyToTheLimit },
                    new Bunny { Name = "Tit", Age = 2, FurType = FurType.FluffyToTheLimit }
                };

            var path = @"..\..\bunnies.txt";

            var engine = new BunniesEngine(bunnies, path);
            engine.IntroduceBunnies();
            engine.SaveBunniesToATextFile();
        }
    }
}