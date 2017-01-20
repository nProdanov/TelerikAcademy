namespace IntergalacticTravel.Tests.Mocks
{
    using System.Collections.Generic;

    using IntergalacticTravel;
    using IntergalacticTravel.Contracts;

    public class MockTeleportationStation : TeleportStation
    {
        public MockTeleportationStation(
            IBusinessOwner owner, 
            IEnumerable<IPath> galacticMap, 
            ILocation location) 
            : base(owner, galacticMap, location)
        {
        }

        public IResources Resources
        {
            get
            {
                return this.resources;
            }
        }

        public IBusinessOwner Owner
        {
            get
            {
                return this.owner;
            }
        }

        public ILocation Location
        {
            get
            {
                return this.location;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return this.galacticMap;
            }
        }
    }
}
