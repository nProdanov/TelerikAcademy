import "./polyfills/array";

import { SuperCreature } from "./models/SuperCreature";
import { AlignmentType } from "./models/types/AlignmentType";
import { Beast } from "./models/Beast";
import { BigHammerPower } from "./models/BigHammerPower";
import { RessurectPower } from "./models/RessurectPower";

let hammer = new BigHammerPower();
let bachiKiko = new SuperCreature("Kiko", 100, 20, AlignmentType.Neutral, hammer);
let kuche = new Beast("doggy", 40, 3, AlignmentType.Evil);

let ressurect = new RessurectPower();
let doctor = new SuperCreature("doc", 100, 10, AlignmentType.Evil, ressurect);

console.log(bachiKiko.hit(kuche, "BigHammer"));
console.log(kuche.health);
console.log(doctor.hit(kuche, "Ressurect"));
console.log(kuche.health);
