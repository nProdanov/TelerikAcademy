'use strict';
function solve(args) {
    var inputStr,
        numArr,
        i,
        length;
    
    inputStr = args[0].split('\n')[1];
    numArr = inputStr.split(' ');

    console.log(FirstLargerThanNeighbours(numArr));

    function FirstLargerThanNeighbours(numArr) {
        length = numArr.length;
        for (i = 0; i < length ; i += 1) {
            if (length === 1) {
                return i;
            }

            if (i === 0) {
                
                    continue;
                
            }
            else if (i === length -1) {
                    break;                
            }
            else{
                if (+numArr[i] > +numArr[i-1] && +numArr[i] > +numArr[i+1]) {
                    return i;
                }
            }
        }
    }
}
