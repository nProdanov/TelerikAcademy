import { IHittable } from "./contracts/IHitable";
import { Creautre } from "./abstracts/Creature";
import { AlignmentType } from "./types/AlignmentType";
import { IPet } from "./contracts/IPet";
import { SuperCreature } from "./SuperCreature";

export class Beast extends Creautre implements IHittable, IPet {
    private _damage: number;

    public master: SuperCreature;

    constructor(name: string, health: number, damage: number, alignment: AlignmentType) {
        super(name, health, alignment);
        this.damage = damage;
        this.master = null;
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

    hit(creatureToHit: Creautre): string {
        creatureToHit.takeHit(this.damage);
        return `${this.name} hit ${creatureToHit.name} with physical damage`;
    }
}