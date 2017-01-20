'use strict';
function solve(args) {
    var inputStr,
        numArr;
    
    
    numArr = args[1].split(' ');
    numArr = Sort(numArr);
    console.log(numArr.join(' '));
   
    function Sort(numArr) {
        var currMax,
            maxPos,
            k;
        for (k = numArr.length-1; k >= 0; k -= 1) {
            maxPos = GetMax(numArr,0,k);
            currMax = numArr[maxPos];
            numArr.splice(maxPos,1);
            numArr.splice(k,0,+currMax);
        }
        return numArr;
    }

    function GetMax(numArr, startInd, endInd) {
        var max = +numArr[startInd];
        var pos =startInd;
        var i;
        for (i = startInd +1 ; i <= endInd ; i += 1) {
            if (max < +numArr[i]) {
                max = +numArr[i];
                pos = i;
            }
        }

        return pos;
    }
}


