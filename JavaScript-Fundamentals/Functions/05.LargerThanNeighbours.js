'use strict';
function solve(args) {
    var inputStr,
        numArr,
        i,
        count,
        length;
    
    inputStr = args[0].split('\n')[1];
    numArr = inputStr.split(' ');

    console.log(CountLargerThanNeighbours(numArr));

    function CountLargerThanNeighbours(numArr) {
        count = 0;
        length = numArr.length;
        for (i = 0; i < length ; i += 1) {
            if (length === 1) {
                return count;
            }
            if (i === 0) {
                
                    continue;
                
            }
            else if (i === length -1) {
               
                    continue;
                
            }
            else{
                if (+numArr[i] > +numArr[i-1] && +numArr[i] > +numArr[i+1]) {
                    count += 1;
                }
            }
        }

        return count;
    }
}

