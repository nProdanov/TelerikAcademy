namespace ArmyOfCreatures.Extended
{
    using System.Collections.Generic;
    using System.Linq;

    using Logic;
    using Logic.Battles;
   
    public class ExtendedBattleManager : BattleManager, IBattleManager
    {
        private const string LogFormat = "--- {0} - {1}";

        private readonly ICollection<ICreaturesInBattle> firstArmyCreatures;
        private readonly ICollection<ICreaturesInBattle> secondArmyCreatures;
        private readonly ICollection<ICreaturesInBattle> thirdArmyCreatures;

        private readonly ICreaturesFactory creaturesFactory;

        private readonly ILogger logger;


        public ExtendedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
            :base(creaturesFactory, logger)
        {
            this.firstArmyCreatures = new List<ICreaturesInBattle>();
            this.secondArmyCreatures = new List<ICreaturesInBattle>();
            this.thirdArmyCreatures = new List<ICreaturesInBattle>();

            this.creaturesFactory = creaturesFactory;
            this.logger = logger;
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            Validator.CheckIfNull(creatureIdentifier, "identifier can not be null!");
            Validator.CheckIfNull(creaturesInBattle, "creatures in battle can not be null!");
            if (creatureIdentifier.ArmyNumber == 3)
            {
                this.thirdArmyCreatures.Add(creaturesInBattle);
            }
            else
            {
                base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);

            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            Validator.CheckIfNull(identifier, "identifier can not be null!");
            if (identifier.ArmyNumber == 3)
            {
                return this.thirdArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }
            return base.GetByIdentifier(identifier);
        }
    }
}
