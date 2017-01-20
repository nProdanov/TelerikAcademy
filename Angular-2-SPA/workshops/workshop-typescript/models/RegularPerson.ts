import { Creautre } from "./abstracts/Creature";
import { AlignmentType } from "./types/AlignmentType";

export class RegularPerson extends Creautre {
    constructor(name: string, health: number, alignment: AlignmentType) {
        super(name, health, alignment);
    }
}