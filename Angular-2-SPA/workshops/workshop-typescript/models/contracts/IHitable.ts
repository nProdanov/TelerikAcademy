import { Creautre } from "../abstracts/Creature";

export interface IHittable {
    damage: number
    hit(creatureToHit: Creautre, power?: string) : string
}