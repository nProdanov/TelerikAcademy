namespace TradeAndTravel
{
    using System.Linq;
    using System.Text;

    class CustomInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                  
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }

            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "craft":
                    var weaponComposingItems = Weapon.GetComposingItems();
                    if (commandWords[2] == "weapon")
                    {
                       
                        if (actor.ListInventory().Any(i => i.ItemType == weaponComposingItems[0]))
                        {
                            if (actor.ListInventory().Any(i => i.ItemType == weaponComposingItems[1]))
                            {
                                this.AddToPerson(actor, new Weapon(commandWords[3], actor.Location));
                            }

                        }
                    }
                    else
                    {
                        if (actor.ListInventory().Any(i => i.ItemType == weaponComposingItems[0]))
                        {
                            this.AddToPerson(actor, new Armor(commandWords[3], actor.Location));
                        }
                    }
                    break;
                case "gather":
                    if(actor.Location is IGatheringLocation)
                    {
                        var a = actor.Location as IGatheringLocation;
                        if(actor.ListInventory().Any(i => i.ItemType == a.RequiredItem))
                        {
                            this.AddToPerson(actor, a.ProduceItem(commandWords[2]));
                        }
                    }
                    //if(actor.Location.LocationType == LocationType.Forest)
                    //{
                    //    if(actor.ListInventory().Any(i => i.ItemType == ItemType.Weapon))
                    //    {
                    //       item =  this.CreateItem("wood", commandWords[2], actor.Location,item);
                    //        this.AddToPerson(actor, item);
                    //    }
                    //    return;
                    //}
                    //else if(actor.Location.LocationType == LocationType.Mine)
                    //{
                    //    if (actor.ListInventory().Any(i => i.ItemType == ItemType.Armor))
                    //    {
                    //        item = this.CreateItem("iron", commandWords[2], actor.Location, item);
                    //        this.AddToPerson(actor, item);
                    //    }
                    //}
                    break;
                default:
                     base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
                   
            }
            return person;
            
        }

    }
}
