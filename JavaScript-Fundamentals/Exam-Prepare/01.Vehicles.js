function solve(params) {
    var s = +params[0],
        count = 0,
        ten,
        four,
        three;

    for (ten = 0; ten <= s / 10; ten += 1) {
        for (four = 0; four <= s / 4; four += 1) {
            for (three = 0; three <= s / 3; three += 1) {
                if ((ten * 10 + four * 4 + three * 3) === s) {
                    count += 1;
                }
            }
        }
    }
    console.log(count);
}
