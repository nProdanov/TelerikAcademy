import { Power } from "./abstracts/Power";
import { PowerType } from "./types/PowerType";
import { SuperCreature } from "./SuperCreature";
import { Creautre } from "./abstracts/Creature";
import { AlignmentType } from "./types/AlignmentType";

export class BigHammerPower extends Power {
    constructor() {
        super("BigHammer", PowerType.Destructive, 50);
    }

    applyPower(attacker: SuperCreature, creatureToApply: Creautre) {
        if (attacker.alignment === AlignmentType.Good && attacker.alignment === creatureToApply.alignment) {
            return;
        }

        creatureToApply.takeHit(this.healthImpact);
    }
}