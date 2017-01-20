function solve(params) {
    var nk = params[0].split(' ').map(Number),
        arrNum = params[1].split(' ').map(Number),
        result,
        tempArr,
        n,
        k,
        i,
        j;

    n = nk[0];
    k = nk[1];
    result = 0;
    for (i = 0; i < k; i += 1) {
        tempArr = [];
        for (j = 0; j < n; j += 1) {
            if (arrNum[j] === 0) {
                if (j === 0) {
                    tempArr.push(Math.abs(arrNum[n - 1] - arrNum[1]));
                }
                else if (j === (n - 1)) {
                    tempArr.push(Math.abs(arrNum[n - 2] - arrNum[0]));
                }
                else {
                    tempArr.push(Math.abs(arrNum[j - 1] - arrNum[j + 1]));
                }
            }
            else if (arrNum[j] === 1) {
                if (j === 0) {
                    tempArr.push(arrNum[n - 1] + arrNum[1]);
                }
                else if (j === (n - 1)) {
                    tempArr.push(arrNum[n - 2] + arrNum[0]);
                }
                else {
                    tempArr.push(arrNum[j - 1] + arrNum[j + 1]);
                }
            }
            else if (arrNum[j] % 2) {
                if (j === 0) {
                    tempArr.push(min(arrNum[n - 1], arrNum[1]));
                }
                else if (j === n - 1) {
                    tempArr.push(min(arrNum[n - 2], arrNum[0]));
                }
                else {
                    tempArr.push(min(arrNum[j - 1], arrNum[j + 1]));
                }
            }
            else {
                if (j === 0) {
                    tempArr.push(max(arrNum[n - 1], arrNum[1]));
                }
                else if (j === n - 1) {
                    tempArr.push(max(arrNum[n - 2], arrNum[0]));
                }
                else {
                    tempArr.push(max(arrNum[j - 1], arrNum[j + 1]));
                }
            }
            if (i + 1 === k) {
                result += tempArr[j];
            }
        }

        arrNum = DeepCopy(tempArr);
    }


    if (k === 0){
        for (i = 0; i < n; i += 1) {
            result +=arrNum[i];
        }
    }
    
    console.log(result);



    function min(a, b) {
        if (a > b) {
            return b;
        }

        return a;
    }

    function max(a, b) {
        if (a > b) {
            return a;
        }

        return b;
    }

    function DeepCopy(obj) {
        if (typeof (obj) !== 'object') {
            return obj;
        }
        else {
            var clone = {};
            for (var key in obj) {
                clone[key] = DeepCopy(obj[key]);
            }
            return clone;
        }
    }
}

solve([
    '10 3',
    '1 9 1 9 1 9 1 9 1 9'
]);
