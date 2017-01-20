namespace IntergalacticTravel.Tests
{
    using IntergalacticTravel;
    using IntergalacticTravel.Exceptions;

    using NUnit.Framework;

    [TestFixture]
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnitShouldReturnANewInstanceOfProcyonWhenValidCommandIsPassed()
        {
            var validCommand = "create unit Procyon Gosho 1";
            var unitsFactory = new UnitsFactory();

            var procyonTest = unitsFactory.GetUnit(validCommand);

            Assert.IsInstanceOf<Procyon>(procyonTest);
        }

        [Test]
        public void GetUnitShouldReturnANewInstanceOfLuytenWhenValidCommandIsPassed()
        {
            var validCommand = "create unit Luyten Pesho 2";
            var unitsFactory = new UnitsFactory();

            var luytenTest = unitsFactory.GetUnit(validCommand);

            Assert.IsInstanceOf<Luyten>(luytenTest);
        }

        [Test]
        public void GetUnitShouldReturnANewInstanceOfLacailleWhenValidCommandIsPassed()
        {
            var validCommand = "create unit Lacaille Tosho 3";
            var unitsFactory = new UnitsFactory();

            var lacailleTest = unitsFactory.GetUnit(validCommand);

            Assert.IsInstanceOf<Lacaille>(lacailleTest);
        }

        [Test]
        [TestCase(null)]
        [TestCase("create ")]
        [TestCase("create unit ")]
        [TestCase("create unit Lacaille ")]
        [TestCase("create unit Lacaille Tosho ")]
        [TestCase("create unit Lacaille Tosho id")]
        public void GetUnitShouldThrowAnInvalidUnitCreationCommandExceptionWhenTheCommandPassedIsNotInTheValidFormat(string command)
        {
            var unitsFactory = new UnitsFactory();

            Assert.Throws<InvalidUnitCreationCommandException>(() => unitsFactory.GetUnit(command));
        }
    }
}
