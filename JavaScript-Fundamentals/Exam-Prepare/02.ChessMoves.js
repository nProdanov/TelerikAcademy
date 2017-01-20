'use strict';
function solve(args) {
    var rows = +args[0],
        cols = +args[1],
        chessField = [],
        i,
        countRows,
        command,
        C,
        currRow,
        currCol,
        finalRow,
        finalCol;

    countRows = 2;
    for (i = rows - 1; i >= 0; i -= 1) {
        chessField[i] = args[countRows];
        countRows += 1;
    }

    C = +args[countRows];
    countRows += 1;

    for (i = countRows; i < countRows + C; i += 1) {
        command = commParse(args[i]);
        currRow = command[0];
        currCol = command[1];
        finalRow = command[2];
        finalCol = command[3];
        console.log(checkMoves(chessField, currRow, currCol, finalRow, finalCol));



    }

    function checkMoves(field, currRow, currCol, finalRow, finalCol) {
        var figure = field[currRow][currCol];
        var isClean = true,
            delta,
            deltaC,
            deltaR;
        if (figure == '-') {
            return 'no';
        }

        if (figure === 'R' || figure === 'Q') {
            if (currRow == finalRow || currCol == finalCol) {
                if (currCol == finalCol) {
                    delta = currRow - finalRow;
                    for (let i = finalRow; i !== currRow; i += (delta > 0 ? 1 : -1)) {
                        if (field[i][currCol] !== '-') {
                            isClean = false;
                            break;
                        }
                    }
                    if (isClean) {
                        return 'yes';
                    }
                    else {
                        isClean = true;
                        return 'no';
                    }
                }
                else {
                    delta = currCol - finalCol;
                    for (let i = finalCol; i !== currCol; i += (delta > 0 ? 1 : -1)) {
                        if (field[currRow][i] !== '-') {
                            isClean = false;
                            break;
                        }
                    }
                    if (isClean) {
                        return 'yes';
                    }
                    else {
                        isClean = true;
                        return 'no';
                    }
                }
            }
            else {
                if (figure === 'R') {
                    return 'no';
                }
            }
        }
        if (figure === 'Q' || figure === 'B') {
            deltaR = currRow - finalRow;
            deltaC = currCol - finalCol;
            if (Math.abs(deltaR) === Math.abs(deltaC)) {
                for (let i = finalRow, j = finalCol; i !== currRow; i += deltaR > 0 ? 1 : -1, j += deltaC > 0 ? 1 : -1) {
                    if(field[i][j] !== '-'){
                        isClean = false;
                        break;
                    }
                }
                if(isClean){
                    return 'yes';
                }
                else{
                    return 'no';
                }
            }
            else {
                return 'no';
            }
        }
        return 'no';
    }

    function commParse(comm) {
        var splitedComm = comm.split(' '),
            parsed = [],
            curr = splitedComm[0],
        final = splitedComm[1];
        parsed[0] = +curr[1] - 1;
        parsed[1] = curr[0].charCodeAt() - 97;
        parsed[2] = +final[1] -1;
        parsed[3] = final[0].charCodeAt() - 97;

        return parsed;
    }



}

solve([
    '3',
    '4',
    '--R-',
    'B--B',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 b3',
    'd2 c1',
    'b1 b2',
    'c3 b1',
    'a2 a3',
    'd1 d3',
]);