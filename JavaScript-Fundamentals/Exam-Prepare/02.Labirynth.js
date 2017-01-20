function solve(args) {
    var first = args[0].split(' '),
        second = args[1].split(' '),
        dirMatrix = [],
        valueMatrix = [],
        currRow = +second[0],
        currCol = +second[1],
        rows = +first[0],
        cols = +first[1],
        i,
        j,
        count,
        sum,
        nextRow,
        nextCol,
        nrc;

    // dirMatrix
    for (i = 0; i < rows; i += 1) {
        dirMatrix[i] = args[i + 2];
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


    while (true) {
        nrc = getNext(dirMatrix[currRow][currCol], currRow, currCol);
        nextRow = nrc[0];
        nextCol = nrc[1];
        if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols) {
            console.log('out ' + sum);
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
            console.log('lost ' + count);
            break;
        }

    }

    function getNext(command, currRow, currCol) {
        var rc = [];
        switch (command) {
            case 'd':
                rc[0] = currRow + 1;
                rc[1] = currCol;
                break;
            case 'u':
                rc[0] = currRow - 1;
                rc[1] = currCol;
                break;
            case 'l':
                rc[0] = currRow;
                rc[1] = currCol - 1;
                break;
            case 'r':
                rc[0] = currRow;
                rc[1] = currCol + 1;
                break;
        }
        return rc;
    }

}

solve([
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"
]);