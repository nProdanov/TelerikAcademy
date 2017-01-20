import { Creautre } from "./abstracts/Creature";
import { Power } from "./abstracts/Power";
import { IHittable } from "./contracts/IHitable";
import { AlignmentType } from "./types/AlignmentType";
import { IPet } from "./contracts/IPet";
import { PowerType } from "./types/PowerType";

export class SuperCreature extends Creautre implements IHittable {
    private _damage: number;
    private _powers: Power[];

    public pets: IPet[];

    constructor(name: string, health: number, damage: number, alignement: AlignmentType, ...powers: Power[]) {
        super(name, health, alignement);
        this.damage = damage;
        this._powers = powers;
    }

    public get damage(): number {
        return this._damage;
    }

    public set damage(value: number) {
        if (value < 0) {
            throw new Error("Damage cannot be negative");
        }

        this._damage = value;
    }

    addPet(petToAd: IPet) {
        petToAd.master = this;
    }

    hit(creatureToApply: Creautre, power: string): string {
        if (power === "physical") {
            creatureToApply.takeHit(this.damage);
        }
        else {
            let foundPower = this._powers.filter(p => p.name === power)[0];

            if (!foundPower) {
                throw new Error("No such a power in this attacker");
            }

            foundPower.applyPower(this, creatureToApply);
        }

        return `${this.name} hit ${creatureToApply.name} with ${power} `;
    }
}