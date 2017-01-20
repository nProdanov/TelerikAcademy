'use strict';
function solve(args) {
    var pointsArr,
        currPoint,
        linesArr,
        i,
        k,
        count;

    count = 0;
    pointsArr = [];
    for (i = 0; i < 6; i += 1) {
        currPoint = [];
        for (k = 0; k < 2; k += 1) {
            currPoint[k] = +args[count];
            count += 1;
        }

        pointsArr[i] = MakePoints(currPoint[0], currPoint[1]);
    }

    linesArr = [];
    linesArr[0] = MakeLine(pointsArr[0], pointsArr[1]);
    linesArr[1] = MakeLine(pointsArr[2], pointsArr[3]);
    linesArr[2] = MakeLine(pointsArr[4], pointsArr[5]);
    for (pos in linesArr) {
        console.log(linesArr[pos].toFixed(2));
    }
    if ((linesArr[0] + linesArr[1] > linesArr[2])
        && (linesArr[0] + linesArr[2] > linesArr[1])
        && (linesArr[1] + linesArr[2] > linesArr[0])) {
        console.log('Triangle can be built');
    }
    else {
        console.log('Triangle can not be built');
    }

    function MakeLine(p1, p2) {
        var dist,
            dX,
            dY;

        dX = p1['x'] - p2['x'];
        dY = p1['y'] - p2['y'];
        dist = Math.sqrt((dX * dX) + (dY * dY));
        return dist;
    }

    function MakePoints(x, y) {
        return { 'x': x, 'y': y };
    }
}