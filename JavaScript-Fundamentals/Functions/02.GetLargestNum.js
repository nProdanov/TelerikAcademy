'use strict';
function solve(args) {
    var strArr,
        first,
        second,
        third,
        max;

    strArr = args[0].split(' ');
    first = +strArr[0];
    second = +strArr[1];
    third = +strArr[2];

    max = GetMax(first, second);
    max = GetMax(max, third);
    console.log(max);
    


    function GetMax(first, second) {
        if (first > second) {
            return first;
        }
        else{
            return second;
        }
    }
}