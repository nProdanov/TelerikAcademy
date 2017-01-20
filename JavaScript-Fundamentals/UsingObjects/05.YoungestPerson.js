'use strict';
function solve(args) {
    var propArr,
        people,
        i,
        k,
        pos;

    MakePerson.prototype.toString = function () {
        return this.firstName + ' ' + this.lastName;
    };

    people = [];
    for (i = 0, pos = 0; i < args.length / 3; i += 1) {
        propArr = [];
        for (k = 0; k < 3; k += 1) {
            propArr[k] = args[pos];
            pos += 1;
        }

        people[i] = new MakePerson(propArr[0], propArr[1], propArr[2]);
    }

    people.sort(function (a, b) {
        return a.age - b.age;
    });

    console.log(people[0].toString());

    function MakePerson(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

}