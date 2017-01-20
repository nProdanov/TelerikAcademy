namespace IntergalacticTravel.Tests
{
    using System.Collections.Generic;

    using IntergalacticTravel;
    using IntergalacticTravel.Contracts;
    using IntergalacticTravel.Exceptions;

    using Mocks;

    using NUnit.Framework;

    using Telerik.JustMock;

    [TestFixture]
    public class TeleportationStationTests
    {
        [Test]
        public void ConstructorShouldSetCorrectlyOwnerFieldWhenNewTeleportationStationIsCreatedWithValidParameteresPassed()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedGalacticMap = Mock.Create<IEnumerable<IPath>>();
            var mockedLocation = Mock.Create<ILocation>();

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedLocation);

            Assert.AreEqual(mockedOwner, teleportationStationInstance.Owner);
        }

        [Test]
        public void ConstructorShouldSetCorrectlyGalacticMapFieldWhenNewTeleportationStationIsCreatedWithValidParameteresPassed()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedGalacticMap = Mock.Create<IEnumerable<IPath>>();
            var mockedLocation = Mock.Create<ILocation>();

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedLocation);

            Assert.AreEqual(mockedGalacticMap, teleportationStationInstance.GalacticMap);
        }

        [Test]
        public void ConstructorShouldSetCorrectlyLocationFieldWhenNewTeleportationStationIsCreatedWithValidParameteresPassed()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedGalacticMap = Mock.Create<IEnumerable<IPath>>();
            var mockedLocation = Mock.Create<ILocation>();

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedLocation);

            Assert.AreEqual(mockedLocation, teleportationStationInstance.Location);
        }

        [Test]
        public void TeleportUnitShouldThrowAnArgumenNullExceptionWithMessageThatContainsTheStringUnitToTeleportWhenUnitToTeleportIsNull()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedGalacticMap = Mock.Create<IEnumerable<IPath>>();
            var mockedLocation = Mock.Create<ILocation>();
        
            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedLocation);

            IUnit nullUnitToTeleport = null;
            var mockedTargetLocation = Mock.Create<ILocation>();
            var expectedContainingStringInMessage = "unitToTeleport";

            Assert.That(
                () => teleportationStationInstance.TeleportUnit(nullUnitToTeleport, mockedTargetLocation), 
                Throws.ArgumentNullException.With.Message.Contains(expectedContainingStringInMessage));
        }

        [Test]
        public void TeleportUnitShouldThrowAnArgumenNullExceptionWithMessageThatContainsTheStringDestinationtWhenUnitToTeleportIsNull()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedGalacticMap = Mock.Create<IEnumerable<IPath>>();
            var mockedLocation = Mock.Create<ILocation>();

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedLocation);

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            ILocation nullTargetLocation = null;
            var expectedContainingStringInMessage = "destination";

            Assert.That(
                () => teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, nullTargetLocation),
                Throws.ArgumentNullException.With.Message.Contains(expectedContainingStringInMessage));
        }

        [Test]
        public void TeleportUnitShouldThrowATeleportOutOfRangeExceptionWithMessageThatContainsTheStringUnitToTeleportotCurrentLocationWhenAUnitIsAtDifferentPlanet()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedGalacticMap = Mock.Create<IEnumerable<IPath>>();
            var mockedCurrentLocation = Mock.Create<ILocation>();

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");
            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            var mockedUnitPlanet = Mock.Create<IPlanet>();
            var mocketTargetLocation = Mock.Create<ILocation>();

            Mock.Arrange(() => mockedUnitPlanet.Name).Returns("unitPlanet");
            Mock.Arrange(() => mockedUnitPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedUnitPlanet);

            var expectedContainingMessage = "unitToTeleport.CurrentLocation";

            TeleportOutOfRangeException ex = Assert.Throws<TeleportOutOfRangeException>(() => teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void TeleportUnitShouldThrowATeleportOutOfRangeExceptionWithMessageThatContainsTheStringUnitToTeleportotCurrentLocationWhenAUnitIsAtDifferentGalaxy()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedGalacticMap = Mock.Create<IEnumerable<IPath>>();
            var mockedCurrentLocation = Mock.Create<ILocation>();

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();

            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");
            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            var mockedUnitPlanet = Mock.Create<IPlanet>();
            var mocketTargetLocation = Mock.Create<ILocation>();

            Mock.Arrange(() => mockedUnitPlanet.Name).Returns("unitPlanet");
            Mock.Arrange(() => mockedUnitPlanet.Galaxy.Name).Returns("unitGalaxy");
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedUnitPlanet);

            var expectedContainingMessage = "unitToTeleport.CurrentLocation";

            TeleportOutOfRangeException ex = Assert.Throws<TeleportOutOfRangeException>(() => teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void TeleportUnitShouldThrowALocationNotFoundExceptionWithMessageThatConstainsTheStringGalaxyWhenGalaxyTargetIsNotInTeleportStationMap()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedCurrentLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath };

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");

            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Galaxy.Name).Returns("AnotherGalaxy");
            

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            var mocketTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mocketTargetLocation.Planet.Galaxy.Name).Returns("TargetLocationGaxyName");

            var expectedContainingMessage = "Galaxy";

            LocationNotFoundException ex = Assert.Throws<LocationNotFoundException>(() => teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void TeleportUnitShouldThrowALocationNotFoundExceptionWithMessageThatConstainsTheStringPlanetWhenGalaxyTargetIsNotInTeleportStationMap()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedCurrentLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath };

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");

            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("AnotherPlanet");

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            var mocketTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mocketTargetLocation.Planet.Name).Returns("TargetLocationPlanetName");

            var expectedContainingMessage = "Planet";

            LocationNotFoundException ex = Assert.Throws<LocationNotFoundException>(() => teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void TeleportUnitShouldThrowAnInvalidTeleportationLocationExceptionWithMessageThatConstainsTheStringUnitsWillOverlapWhenOnTargetLocationPlanetThereIsANotherUnitWithSAMeCoordinates()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedCurrentLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath };

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            var mocketTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mocketTargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mocketTargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mocketTargetLocation.Coordinates.Latitude).Returns(20);
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Longtitude).Returns(20);

            var overlappedUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => overlappedUnit.CurrentLocation).Returns(mocketTargetLocation);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Units).Returns(new List<IUnit> { overlappedUnit });

            var expectedContainingMessage = "units will overlap";

            InvalidTeleportationLocationException ex = Assert.Throws<InvalidTeleportationLocationException>(() => teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void TeleportUnitShouldThrowAnInvalidInsufficientResourcesExceptionWithMessageThatConstainsTheStringFreeLunchWhenUnitToTeleportCanNotPay()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedCurrentLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath };

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            var mockedUnitToTeleport = Mock.Create<IUnit>();

            Mock.Arrange(() => mockedUnitToTeleport.CanPay(Arg.IsAny<IResources>())).Returns(false);

            var mocketTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mocketTargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mocketTargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mocketTargetLocation.Coordinates.Latitude).Returns(30);
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Longtitude).Returns(30);

            var notOverlapUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Latitude).Returns(20);
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Longtitude).Returns(20);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Units).Returns(new List<IUnit> { notOverlapUnit });

            var expectedContainingMessage = "FREE LUNCH";

            InsufficientResourcesException ex = Assert.Throws<InsufficientResourcesException>(() => teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void TeleportUnitShouldRequirePaymentFromUnitToTeleportWhenAllValidationPassWithSuccess()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedCurrentLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath };

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            var mockedResource = Mock.Create<IResources>();
            Mock.Arrange(() => mockedPath.Cost).Returns(mockedResource);

            var mockedUnitToTeleport = Mock.Create<IUnit>();

            Mock.Arrange(() => mockedUnitToTeleport.CanPay(Arg.IsAny<IResources>())).Returns(true);

            var mocketTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mocketTargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mocketTargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mocketTargetLocation.Coordinates.Latitude).Returns(30);
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Longtitude).Returns(30);

            var notOverlapUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Latitude).Returns(20);
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Longtitude).Returns(20);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Units).Returns(new List<IUnit> { notOverlapUnit });

            teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation);

            Mock.Assert(() => mockedUnitToTeleport.Pay(Arg.IsAny<IResources>()), Occurs.Once());
        }

        [Test]
        public void TeleportUnitShouldObtainPaymentFromUnitToTeleportWhenAllValidationPassWithSuccess()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedCurrentLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath };

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            var mockedResource = Mock.Create<IResources>();
            Mock.Arrange(() => mockedResource.GoldCoins).Returns(1);
            Mock.Arrange(() => mockedPath.Cost).Returns(mockedResource);

            var mockedUnitToTeleport = Mock.Create<IUnit>();

            Mock.Arrange(() => mockedUnitToTeleport.CanPay(Arg.IsAny<IResources>())).Returns(true);

            var mocketTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mockedUnitToTeleport.Pay(Arg.IsAny<IResources>())).Returns(mockedResource);

            Mock.Arrange(() => mocketTargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mocketTargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Latitude).Returns(30);
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Longtitude).Returns(30);

            var notOverlapUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Latitude).Returns(20);
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Longtitude).Returns(20);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Units).Returns(new List<IUnit> { notOverlapUnit });

            teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation);

            Assert.AreEqual(mockedResource.GoldCoins, teleportationStationInstance.Resources.GoldCoins);
        }

        [Test]
        public void TeleportUnitShouldSetUnitToTeleportPreviusLocationToItsCurrentLocation()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedCurrentLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath };

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            var mockedResource = Mock.Create<IResources>();
            Mock.Arrange(() => mockedResource.GoldCoins).Returns(1);
            Mock.Arrange(() => mockedPath.Cost).Returns(mockedResource);

            var mockedUnitToTeleport = Mock.Create<IUnit>();

            Mock.Arrange(() => mockedUnitToTeleport.CanPay(Arg.IsAny<IResources>())).Returns(true);

            var mocketTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mockedUnitToTeleport.Pay(Arg.IsAny<IResources>())).Returns(mockedResource);

            Mock.Arrange(() => mocketTargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mocketTargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Latitude).Returns(30);
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Longtitude).Returns(30);

            var notOverlapUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Latitude).Returns(20);
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Longtitude).Returns(20);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Units).Returns(new List<IUnit> { notOverlapUnit });

            teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation);

            Mock.ArrangeSet(() => mockedUnitToTeleport.PreviousLocation = Arg.IsAny<ILocation>()).MustBeCalled();
        }

        [Test]
        public void TeleportUnitShouldSetUnitToTeleportCurrentLocationToTargetLocation()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedCurrentLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            var mockedGalacticMap = new List<IPath> { mockedPath };

            var teleportationStationInstance = new MockTeleportationStation(mockedOwner, mockedGalacticMap, mockedCurrentLocation);

            var mockedCurrentPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("currentGalaxy");
            Mock.Arrange(() => mockedCurrentPlanet.Name).Returns("currentPlanet");
            Mock.Arrange(() => mockedCurrentPlanet.Galaxy.Name).Returns("anotherGalaxy");

            Mock.Arrange(() => mockedCurrentLocation.Planet).Returns(mockedCurrentPlanet);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");

            var mockedResource = Mock.Create<IResources>();
            Mock.Arrange(() => mockedResource.GoldCoins).Returns(1);
            Mock.Arrange(() => mockedPath.Cost).Returns(mockedResource);

            var mockedUnitToTeleport = Mock.Create<IUnit>();

            Mock.Arrange(() => mockedUnitToTeleport.CanPay(Arg.IsAny<IResources>())).Returns(true);

            var mocketTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation.Planet).Returns(mockedCurrentPlanet);
            Mock.Arrange(() => mockedUnitToTeleport.Pay(Arg.IsAny<IResources>())).Returns(mockedResource);

            Mock.Arrange(() => mocketTargetLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => mocketTargetLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Latitude).Returns(30);
            Mock.Arrange(() => mocketTargetLocation.Coordinates.Longtitude).Returns(30);

            var notOverlapUnit = Mock.Create<IUnit>();
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Name).Returns("AnotherPlanet");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Planet.Galaxy.Name).Returns("anotherGalaxy");
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Latitude).Returns(20);
            Mock.Arrange(() => notOverlapUnit.CurrentLocation.Coordinates.Longtitude).Returns(20);

            Mock.Arrange(() => mockedPath.TargetLocation.Planet.Units).Returns(new List<IUnit> { notOverlapUnit });

            teleportationStationInstance.TeleportUnit(mockedUnitToTeleport, mocketTargetLocation);

            Mock.ArrangeSet(() => mockedUnitToTeleport.CurrentLocation = Arg.IsAny<ILocation>()).MustBeCalled();
        }
    }
}
