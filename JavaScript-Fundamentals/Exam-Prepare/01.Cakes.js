function solve(params) {
    var s = +params[0], c1 = +params[1], c2 = +params[2], c3 = +params[3];
    var answer = 0,
        i,
        j,
        k,
        temp =0,
        max = 0;

    found = false;

    for (i = Math.floor(s /c1); i >= 0; i -= 1) {
        for (j = Math.floor(s / c2); j >=0 ; j -= 1) {
            for (k = Math.floor(s / c3); k >= 0; k -= 1) {
                if ((i * c1 + j * c2 + k * c3) === s) {
                    answer = s;
                    found = true;
                }
                else{
                    temp = (i * c1 + j * c2 + k * c3);
                }

                if (temp < s && max < temp) {
                    max = temp;
                }

            }

            if (found) {
                break;
            }
        }

        if (found) {
            break;
        }
    }

    if (!found) {
        answer = max;
    }

    console.log(answer);
}

