function solve(params) {
    var arrNum = params[0].split(' ').map(Number),
        rocksCurrValley,
        rocksMaxValley,
        i;
    rocksCurrValley = 2;
    rocksMaxValley = 2;
    for (i = 2; i < arrNum.length - 1; i += 1) {
        if (i + 1 === arrNum.length -1) {
            rocksCurrValley +=1;
        }
        if (rocksCurrValley > rocksMaxValley) {
            rocksMaxValley = rocksCurrValley;
        }
        if (arrNum[i] > arrNum[i - 1] && arrNum[i] > arrNum[i + 1]) {
            rocksCurrValley = 2;
            i +=1;
            continue;
        }
        rocksCurrValley += 1;
    }

    console.log(rocksMaxValley);


}
