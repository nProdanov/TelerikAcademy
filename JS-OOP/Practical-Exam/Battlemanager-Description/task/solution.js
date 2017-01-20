function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

    let validator = {
        validateIfUnitObj(value) {
            if (value === undefined) {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }

            if (typeof value.damage !== 'number') {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }

            if (value.damage < 0 || 100 < value.damage) {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }

            if (value.health === undefined) {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }

            if (typeof value.health !== 'number') {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }

            if (value.health < 0 || 200 < value.health) {
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
            }

            if (value.count === undefined) {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }

            if (typeof value.count !== 'number') {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }

            if (value.count < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }
        },
        validateIfNameValid: function (name) {
            this.validateIfUndefined(name);
            if (typeof name !== 'string') {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
            if (name.length < 2 || 20 < name.length) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
            if (!(/^[a-zA-Z ]*$/.test(name))) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        validateIfManaValid: function (manaCOst) {
            this.validateIfUndefined(manaCOst);
            if (typeof manaCOst !== 'number' || isNaN(manaCOst)) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
            if (manaCOst <= 0) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        validateIfUndefined: function (value) {
            if (value === undefined) {
                throw new Error('undefined');
            }
        },
        validateSpecial: function (name) {
            this.validateIfUndefined(name);
            if (typeof name !== 'string') {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }

            if (name.length < 2 || 20 < name.length) {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }

            if (!(/^[a-zA-Z ]*$/.test(name))) {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
        },
        validateSpecTwo: function (manaCOst) {
            this.validateIfUndefined(manaCOst);
            if (typeof manaCOst !== 'number') {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }

            if (manaCOst <= 0) {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
        },
        validateSpexThree: function (value) {
            if (typeof value !== 'function') {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }

            if (value.length !== 1) {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
        },
        validateIfNumberInRange(value, min, max, message) {
            validator.validateIfUndefined(value);
            if (typeof value !== 'number') {
                throw new Error(message);
            }

            if (value < min || max < value) {
                throw new Error(message);
            }
        }
    };

    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            validator.validateIfNameValid(value);
            this._name = value;
        }

        get manaCost() {
            return this._manaCost;
        }

        set manaCost(value) {
            validator.validateIfManaValid(value);
            this._manaCost = value;
        }

        get effect() {
            return this._effect;
        }

        set effect(value) {
            if (typeof value !== 'function') {
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }

            if (value.length !== 1) {
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }

            this._effect = value;
        }
    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            validator.validateIfNameValid(value);
            this._name = value;
        }

        get alignment() {
            return this._alignment;
        }

        set alignment(value) {
            validator.validateIfUndefined(value);
            if (typeof value !== 'string') {
                throw new Error('Alignment must be good, neutral or evil!');
            }

            if (value !== 'good' && value !== 'neutral' && value !== 'evil') {
                throw new Error('Alignment must be good, neutral or evil!');
            }

            this._alignment = value;
        }
    }

    class commander extends Unit {
        constructor(name, alignment, mana) {
            super(name, alignment);
            this.mana = mana;
            this._army = [];
            this._spellbook = [];
        }

        get mana() {
            return this._mana;
        }

        set mana(value) {
            validator.validateIfUndefined(value);
            validator.validateIfManaValid(value);
            this._mana = value;
        }

        get spellbook() {
            return this._spellbook;
        }

        set spellbook(value) {
            validator.validateIfUndefined(value);
            if (!Array.isArray(value)) {
                throw new Error('Spellbook must be an array');
            }

            this._spellbook = value;
        }

        get army() {
            return this._army;
        }
    }

    let ArmyUnit = (function (parent) {
        let currArmyId = 0;

        class ArmyUnit extends parent {
            constructor(options) {
                validator.validateIfUndefined(options);
                super(options.name, options.alignment);
                this.damage = options.damage;
                this.health = options.health;
                this.count = options.count;
                this.speed = options.speed;
                this._id = ++currArmyId;
            }

            get id() {
                return this._id;
            }

            get damage() {
                return this._damage;
            }

            set damage(value) {
                validator.validateIfUndefined(value);
                if (typeof value !== 'number') {
                    throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
                }
                if (value < 0 || 100 < value) {
                    throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
                }

                this._damage = value;
            }

            get health() {
                return this._health;
            }


            set health(value) {
                validator.validateIfUndefined(value);
                validator.validateIfNumberInRange(value, 0, 200, ERROR_MESSAGES.INVALID_HEALTH);

                this._health = value;
            }

            get count() {
                return this._count;
            }

            set count(value) {
                validator.validateIfUndefined(value);
                validator.validateIfNumberInRange(value, 0, Number.MAX_VALUE, ERROR_MESSAGES.INVALID_COUNT);

                this._count = value;
            }

            get speed() {
                return this._speed;
            }

            set speed(value) {
                validator.validateIfUndefined(value);
                validator.validateIfNumberInRange(value, 0, 100, ERROR_MESSAGES.INVALID_SPEED);

                this._speed = value;
            }
        }

        return ArmyUnit;
    })(Unit);

    let BattleManager = (function () {
        class BattleManager {
            constructor() {
                this.commanders = [];
                this.armyUnits = [];
                this.spells = [];
            }

            getCommander(name, alignment, mana) {
                return new commander(name, alignment, mana);
            }

            getArmyUnit(options) {
                return new ArmyUnit(options);
            }

            getSpell(name, manaCost, effect) {
                return new Spell(name, manaCost, effect);
            }

            addCommanders(...commanders) {
                commanders.filter(commander => {
                    if (commander.name === undefined) {
                        return false;
                    }

                    if (commander.alignment === undefined) {
                        return false;
                    }

                    if (commander.mana === undefined) {
                        return false;
                    }

                    if (commander.spellbook === undefined) {
                        return false;
                    }

                    if (commander.army === undefined) {
                        return false;
                    }
                    else {
                        return true;
                    }
                });

                this.commanders.push(...commanders);
                return this;
            }

            addArmyUnitTo(commanderName, armyUnit) {
                let commanderToAdd = this.commanders.find(commander => commander.name === commanderName);
                commanderToAdd.army.push(armyUnit);

                this.armyUnits.push(armyUnit);
                return this;
            }

            addSpellsTo(commanderName, ...spells) {
                let commanderToAdd = this.commanders.find(comm => comm.name === commanderName);
                let commanderToAddInd = this.commanders.indexOf(commanderToAdd);
                spells.forEach(spell => {
                    validator.validateSpecial(spell.name);
                    validator.validateSpecTwo(spell.manaCost);
                    validator.validateSpexThree(spell.effect);
                });

                commanderToAdd.spellbook.push(...spells);

                this.spells.push(...spells);
                return this;
            }

            findCommanders(query) {
                let commandersToShow = this.commanders
                    .filter(commander => {
                        let isPass = true;
                        for (let prop in query) {
                            if (commander[prop] === undefined || commander[prop] !== query[prop]) {
                                isPass = false;
                                break;
                            }
                        }

                        return isPass;
                    })
                    .sort((commanderF, commanderS) => commanderF.name.localeCompare(commanderS.name));

                return commandersToShow;
            }

            findArmyUnitById(id) {
                let armyunitToShow = this.armyUnits.find(unit => unit.id === id);

                return armyunitToShow;
            }

            findArmyUnits(query) {
                let armyUnitsToShow = this.armyUnits
                    .filter(unit => {
                        let isPass = true;
                        for (let prop in query) {
                            if (unit[prop] === undefined || unit[prop] !== query[prop]) {
                                isPass = false;
                                break;
                            }
                        }

                        return isPass;
                    })
                    .sort(function (first, second) {
                        if (first.speed < second.speed) {
                            return 1;
                        }

                        if (first.speed > second.speed) {
                            return -1;
                        }

                        return first.name.localeCompare(second.name);
                    });

                return armyUnitsToShow;
            }

            spellcast(casterName, spellName, targetUnitId) {
                let caster = this.commanders.find(comm => comm.name === casterName);
                if (caster === undefined) {
                    throw new Error("Can't cast with non-existant commander " + casterName + "!");
                }

                let spell = caster.spellbook.find(sp => sp.name === spellName);
                if (spell === undefined) {
                    throw new Error(casterName + " doesn't know " + spellName);
                }

                if (caster.mana < spell.manaCost) {
                    throw new Error('Not enough mana!');
                }
                
                let targetUnit = this.armyUnits.find(unit => unit.id === targetUnitId);
                if (targetUnit === undefined) {
                    throw new Error('Target not found!');
                }

                spell.effect(targetUnit);
                caster.mana -= spell.manaCost;

                return this;
            }

            battle(attacker, defender) {
                validator.validateIfUnitObj(attacker);
                validator.validateIfUnitObj(defender);

                let damage = attacker.damage * attacker.count;
                let defHealth = defender.health * defender.count;

                if (defHealth < damage) {
                    defender.count = 0;
                }
                else {
                    defHealth -= damage;
                    defender.count = Math.ceil(defHealth / defender.health);
                }

                return this;

            }
        }

        return BattleManager;
    })();

    return new BattleManager();
}

module.exports = solve;