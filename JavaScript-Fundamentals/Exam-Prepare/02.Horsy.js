function solve(args) {
    var rc = args[0].split(' '),
        rows = +rc[0],
        cols = +rc[1],
        dirMatrix = [],
        i,
        j,
        valueMatrix = [],
        currValue,
        currCol,
        currRow,
        nextCol,
        nextRow,
        sum,
        nrc,
        countJumps;

    // dir matrix
    for (i = 0; i < rows; i += 1) {
        dirMatrix[i] = args[i + 1].split('').map(Number);
    }

    //value matrix

    for (i = 0; i < rows; i += 1) {
        valueMatrix[i] = [];
        currValue = 1;
        currValue *= Math.pow(2, i);

        for (j = 0; j < cols; j += 1) {
            valueMatrix[i][j] = currValue;
            currValue -= 1;
        }
    }
    currRow = rows - 1;
    currCol = cols - 1;
    sum = valueMatrix[currRow][currCol];
    valueMatrix[currRow][currCol] = 0;
    countJumps = 1;
    while (true) {
        nrc = getDir(dirMatrix[currRow][currCol], currRow, currCol);
        nextRow = nrc[0];
        nextCol = nrc[1];
        if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols) {
            console.log('Go go Horsy! Collected ' + sum + ' weeds');
            break;
        }
        if (valueMatrix[nextRow][nextCol]) {
            sum += valueMatrix[nextRow][nextCol];
            valueMatrix[currRow][currCol] = 0;
            currRow = nextRow;
            currCol = nextCol;
            countJumps += 1;
        }
        else {
            console.log('Sadly the horse is doomed in ' + countJumps + ' jumps');
            break;
        }
    }

    function getDir(dir, currRow, currCol) {
        var rc = [];
        switch (dir) {
            case 1:
                rc[0] = currRow - 2;
                rc[1] = currCol + 1;
                break;
            case 2:
                rc[0] = currRow - 1;
                rc[1] = currCol + 2;
                break;
            case 3:
                rc[0] = currRow + 1;
                rc[1] = currCol + 2;
                break;
            case 4:
                rc[0] = currRow + 2;
                rc[1] = currCol + 1;
                break;
            case 5:
                rc[0] = currRow + 2;
                rc[1] = currCol - 1;
                break;
            case 6:
                rc[0] = currRow + 1;
                rc[1] = currCol - 2;
                break;
            case 7:
                rc[0] = currRow - 1;
                rc[1] = currCol - 2;
                break;
            case 8:
                rc[0] = currRow - 2;
                rc[1] = currCol - 1;
                break;

        }

        return rc;
    }
}

solve([
    '3 5',
    '54361',
    '43326',
    '52188',
]);