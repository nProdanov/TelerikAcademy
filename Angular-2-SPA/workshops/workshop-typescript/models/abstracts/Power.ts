import { PowerType } from "../types/PowerType";
import { SuperCreature } from "../SuperCreature";
import { Creautre } from "../abstracts/Creature";

export abstract class Power {
    public name: string;
    public powerType: PowerType;
    public healthImpact: number;

    constructor(name: string, powerType: PowerType, healthImpact: number) {
        this.name = name;
        this.powerType = powerType;
        this.healthImpact = healthImpact;
    }

    abstract applyPower(attacker: SuperCreature, creatureToApply: Creautre);
}