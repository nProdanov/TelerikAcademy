function solve(args){
	var currNum,
		lenght,
		min,
		max,
		sum,
		average,
		i;

	length = args.length;
	min = +args[0];
	max = +args[0];
	sum = +args[0];
	average =0;

	for (i = 1; i < length; i +=1) {
		currNum = +args[i];
		if (min > currNum) {
			min = currNum;
		}

		if (max < currNum) {
			max = currNum;
		}

		sum += currNum;

	}

	average = sum /length;

	console.log('min=' + min.toFixed(2));
	console.log('max=' + max.toFixed(2));
	console.log('sum=' + sum.toFixed(2));
	console.log('avg=' + average.toFixed(2));
}

solve(['3', '2', '5', '1']);