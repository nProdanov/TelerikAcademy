import { ITakableHit } from "../contracts/ITakebleHit";
import { AlignmentType } from "../types/AlignmentType";

export abstract class Creautre implements ITakableHit {
    private _name: string;
    private _health: number;

    public alignment: AlignmentType;

    constructor(name: string, health: number, alignment: AlignmentType) {
        this.name = name;
        this.health = health;
        this.alignment = alignment;
    }

    public get name(): string {
        return this._name;
    }

    public set name(value: string) {
        if (value === "" ||
            value.length < 3 ||
            value.length > 30) {
            throw new Error("Name is not valid");
        }

        this._name = value;
    }

    public get health(): number {
        return this._health;
    }

    public set health(value: number) {
        if (value < 0) {
            throw new Error("Health cannot be negative");
        }

        this._health = value;
    }

    takeHit(damage: number) {
        if (this.health - damage <= 0) {
            this.health = 0;
        }
        else{
            this.health -= damage;
        }
    }

}