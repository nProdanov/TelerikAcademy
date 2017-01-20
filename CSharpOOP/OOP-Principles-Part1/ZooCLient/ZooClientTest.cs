namespace ZooCLient
{
    using System;
    using System.Collections.Generic;

    using Animals;

    class ZooClientTest
    {
        static void Main()
        {
            var cats = CreateCatArr();
            Console.WriteLine("Cats:");
            ShowMeAnimlas(cats);


            var dogs = CreateDogArr();
            Console.WriteLine("Dogs:");
            ShowMeAnimlas(dogs);


            var frogs = CreateFrogArr();
            Console.WriteLine("Frogs:");
            ShowMeAnimlas(frogs);

        }

        public static void ShowMeAnimlas(IEnumerable<Animal> zoo)
        {
            foreach (var animal in zoo)
            {
                System.Console.WriteLine(animal);
            }
            Console.WriteLine(string.Format("Average age: {0}", Animal.Average(zoo)));
            Console.WriteLine();
        }

        public static Frog[] CreateFrogArr()
        {
            var greengo = new Frog("Greengo", Sex.Male);
            greengo.GrowUp();
            greengo.GrowUp();
            greengo.GrowUp();
            greengo.GrowUp();
            greengo.GrowUp();

            var john = new Frog("John", Sex.Male);
            john.GrowUp();
            john.GrowUp();
            john.GrowUp();
            john.GrowUp();

            var dina = new Frog("Dina", Sex.Female);
            dina.GrowUp();
            dina.GrowUp();

            var frogs = new Frog[] { greengo, john, dina };

            return frogs;
        }

        public static Dog[] CreateDogArr()
        {
            var kudo = new Dog("Kudo", Sex.Male);
            kudo.GrowUp();

            var ben = new Dog("Ben", Sex.Male);
            ben.GrowUp();

            var dxtra = new Dog("Diixtra", Sex.Female);
            dxtra.GrowUp();
            dxtra.GrowUp();

            var sam = new Dog("Sam", Sex.Male);
            sam.GrowUp();
            sam.GrowUp();
            sam.GrowUp();

            var dogs = new Dog[] { kudo, ben, dxtra, sam };

            return dogs;
        }

        public static Cat[] CreateCatArr()
        {
            var dara = new Kitten("Dara");
            dara.GrowUp();
            dara.GrowUp();

            var tom = new Tomcat("Tom");
            tom.GrowUp();
            tom.GrowUp();
            tom.GrowUp();
            tom.GrowUp();

            var ema = new Kitten("Ema");
            ema.GrowUp();
            ema.GrowUp();
            ema.GrowUp();

            var eddy = new Tomcat("Eddy");
            eddy.GrowUp();

            var cats = new Cat[] { dara, tom, ema, eddy };
            return cats;
        }
    }
}
