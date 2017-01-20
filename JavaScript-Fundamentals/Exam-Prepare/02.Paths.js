function solve(args) {
    var rc = args[0].split(' '),
        rows = +rc[0],
        cols = +rc[1],
        dirMatrix = [],
        i,
        j,
        valueMatrix = [],
        currValue,
        currRow = 0,
        currCol = 0,
        nextRow,
        nextCol,
        sum,
        nrc;

    // matrix of directions
    for (i = 0; i < rows; i += 1) {
        dirMatrix[i] = args[i + 1].split(' ');
    }

    // matrix of values
    for (i = 0; i < rows; i += 1) {
        valueMatrix[i] = [];
        currValue = 1;
        currValue *= Math.pow(2, i);
        for (j = 0; j < cols; j += 1) {
            valueMatrix[i][j] = currValue;
            currValue += 1;
        }
    }
    
    sum = valueMatrix[currRow][currCol];
    valueMatrix[currRow][currCol] = 0;
    while (true) {
        nrc = readDir(dirMatrix[currRow][currCol],currRow, currCol);
        nextRow = nrc[0];
        nextCol = nrc[1];
        if(nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols){
            console.log('successed with ' + sum);
            break;
        }
        if(valueMatrix[nextRow][nextCol]){
            sum += valueMatrix[nextRow][nextCol];
            valueMatrix[nextRow][nextCol] = 0;
            currRow = nextRow;
            currCol = nextCol;
        }
        else{
            console.log('failed at (' + nextRow + ', ' + nextCol + ')');
            break;
        }

    }

    function readDir(str,currRow, currCol) {
        var rc = str;
        var result = [];
        switch(rc[0]){
            case 'u' : result[0] = currRow -1; break;
            case 'd' : result[0] = currRow + 1; break;
        }

        switch(rc[1]){
            case 'l' : result[1] = currCol -1; break;
            case 'r' : result[1] = currCol + 1; break;
        }
        return result;
    }
    

}

solve([
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
]);