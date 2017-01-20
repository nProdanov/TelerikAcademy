function solve(params) {
    var n = +params[0];
    var k = +params[1];
    var arrNum = params[2].split(' ').map(Number);
    var i,
        j,
        min,
        max,
        sumArr;

    sumArr = [];
    for (i = 0; i <= n - k; i += 1) {
        min = arrNum[i];
        max = arrNum[i];
        for (j = i; j < i + k; j += 1) {
            if (arrNum[j] > max) {
                max = arrNum[j];
            }
            if (arrNum[j] < min) {
                min = arrNum[j];
            }
        }

        sumArr.push(min + max);
    }
    console.log(sumArr.join(','));
}
