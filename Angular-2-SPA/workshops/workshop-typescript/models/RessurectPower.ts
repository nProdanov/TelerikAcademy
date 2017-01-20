import { Power } from "./abstracts/Power";
import { PowerType } from "./types/PowerType";
import { SuperCreature } from "./SuperCreature";
import { Creautre } from "./abstracts/Creature";

export class RessurectPower extends Power {
    constructor() {
        super("Ressurect", PowerType.Helpful, 100);
    }

    applyPower(attacker: SuperCreature, creatureToApply: Creautre) {
        if (attacker.alignment === creatureToApply.alignment && creatureToApply.health === 0) {
            creatureToApply.health = this.healthImpact;
        }
    }
} 