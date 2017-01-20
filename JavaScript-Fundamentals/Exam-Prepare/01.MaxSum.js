function solve(params) {
    var N = +params[0];
    var answer = 0;
    var arrNum,
        isNegative;

    arrNum = params.filter(function (item, index) {
        return index > 0;
    }).
        map(Number);


    answer = contiguousSubArrayWithLargestsum(arrNum, N);

    isNegative = arrNum.every(function (item) {
        return item < 0;
    });

    if (isNegative) {
        arrNum.sort(function (a, b) {
            return b -a;
        });
        answer = arrNum[0];
    }

    return answer;

    function contiguousSubArrayWithLargestsum(a, size) {

        var startIndex = 0, endIndex = 0;
        var index;
        var currStartIndex = 0;

        var maxSum = 0;
        var currentSum = 0;

        for (index = 0; index < size; index += 1) {
            currentSum = currentSum + a[index];
            // case 1 : When ith element can be included
            // Change the end index and also update the start index.
            if (currentSum > maxSum) {
                maxSum = currentSum;
                endIndex = index;
                startIndex = currStartIndex;
            }
            /*case 2 : When ith index cannot be included and 
            we need to start with i+1 index. till now our max sum
            and start and end index of that sum remain same */
            if (currentSum < 0) {
                currStartIndex = index + 1;
                currentSum = 0;
            }
        }

        return maxSum;
    }
}
