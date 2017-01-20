function solve(args) {
    var first = args[0].split(' '),
        second = args[1].split(' '),
        dirArr = [],
        valueMatrix = [],
        currRow = +second[0],
        currCol = +second[1],
        rows = +first[0],
        cols = +first[1],
        jumps = +first[2],
        i,
        j,
        count,
        sum,
        nextRow,
        nextCol,
        nrc;

    // dirMatrix
    for (i = 0; i < jumps; i += 1) {
        dirArr[i] = args[i + 2].split(' ');
    }

    //value MAtrix
    count = 1;
    for (i = 0; i < rows; i += 1) {
        valueMatrix[i] = [];
        for (j = 0; j < cols; j += 1) {
            valueMatrix[i][j] = count;
            count += 1;
        }
    }

    count = 1;
    sum = valueMatrix[currRow][currCol];
    valueMatrix[currRow][currCol] = 0;

    countDirs = 0;
    while (true) {
        nrc = getNext(dirArr[countDirs], currRow, currCol);
        countDirs +=1;
        if (countDirs == jumps){
            countDirs = 0;
        }
        nextRow = nrc[0];
        nextCol = nrc[1];
        if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols) {
            console.log('escaped ' + sum);
            break;
        }
        if (valueMatrix[nextRow][nextCol]) {
            sum += valueMatrix[nextRow][nextCol];
            valueMatrix[nextRow][nextCol] = 0;
            currRow = nextRow;
            currCol = nextCol;
            count += 1;
        }
        else {
            console.log('caught ' + count);
            break;
        }

    }

    function getNext(command, currRow, currCol) {
        var rc = [],
            commR = +command[0],
            commC = +command[1];
        currRow += commR;
        currCol += commC;
        rc[0] = currRow;
        rc[1] = currCol;
        return rc;
    }

}

solve([
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1',
]);