'use strict';
function solve(args) {
    var inputStr,
        numArr,
        xNum,
        i,
        count;

    inputStr = args[0].split('\n');
    numArr = inputStr[1].split(' ');
    xNum = +inputStr[2];

    console.log(CountAppearance(numArr, xNum));

    function CountAppearance(numArr, xNum) {
        count =0;
        for (i = 0; i < numArr.length; i += 1) {
            if (+numArr[i] === xNum ) {
                count += 1;        
            }   
        }
        return count;
    }
}
