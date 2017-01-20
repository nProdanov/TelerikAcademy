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
            deltaR,
            tempRow,
            tempCol;
        if (figure == '-') {
            return 'no';
        }

        if (currRow === finalRow && currCol === finalCol) {
            return 'no';
        }

        if (figure === 'Q') {
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

            deltaR = currRow - finalRow;
            deltaC = currCol - finalCol;
            if (Math.abs(deltaR) === Math.abs(deltaC)) {
                for (let i = finalRow, j = finalCol; i !== currRow; i += deltaR > 0 ? 1 : -1, j += deltaC > 0 ? 1 : -1) {
                    if (field[i][j] !== '-') {
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
                return 'no';
            }
        }
        else {
            if (currRow === finalRow || currCol === finalCol) {
                return 'no';
            }
            else {
                if (field[finalRow][finalCol] !== '-') {
                    return 'no';
                }
                if (currRow > finalRow) {
                   if(currRow - 1 === finalRow && currCol - 2 === finalCol){
                       return 'yes';
                   }
                   if(currRow - 2 === finalRow && currCol - 1 === finalCol){
                       return 'yes';
                   }
                   if(currRow - 2 === finalRow && currCol + 1 === finalCol){
                       return 'yes';
                   }
                   if(currRow - 1 === finalRow && currCol + 2 === finalCol){
                       return 'yes';
                   }
                   return 'no';
                }
                else {
                   if(currRow + 1 === finalRow && currCol + 2 === finalCol){
                       return 'yes';
                   }
                   if(currRow + 2 === finalRow && currCol + 1 === finalCol){
                       return 'yes';
                   }
                   if(currRow + 2 === finalRow && currCol -1 === finalCol){
                       return 'yes';
                   }
                   if(currRow + 1 === finalRow && currCol - 2 === finalCol){
                       return 'yes';
                   }
                   return 'no';
                }
            }
        }
    }
    function commParse(comm) {
        var splitedComm = comm.split(' '),
            parsed = [],
            curr = splitedComm[0],
            final = splitedComm[1];
        parsed[0] = +curr[1] - 1;
        parsed[1] = curr[0].charCodeAt() - 97;
        parsed[2] = +final[1] - 1;
        parsed[3] = final[0].charCodeAt() - 97;

        return parsed;
    }
}

solve([
    '9',
    '13',
    '-------------',
    '--K-------K--',
    '---K-------K-',
    '--K----------',
    '-----K------K',
    '-------------',
    '--K------K---',
    '---K----K----',
    '---------K---',
    '10',
    'd2 b1',
    'c3 b1',
    'f5 h6',
    'k8 a9',
    'c8 d6',
    'c6 d8',
    'j1 a9',
    'j3 l5',
    'k8 f7',
    'm5 m3',
]);
// 0 1 2 3 4 5 6 7 8 9
// a b c d e f g h i j 
//8- - - - - K - - - -7
//7- - - - - - - - - -6
//6- - - Q - - - - X K5
//5- - - - - - - - - -4
//4- Q - - - - - - - -3
//3- - - - - - - K - -2
//2- - - - - - - - - K1
//1- K - - - - - - - -0
 //a b c d e f g h i j 