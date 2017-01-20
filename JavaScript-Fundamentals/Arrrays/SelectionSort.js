function solve(args){
	var input,
		arr,
		minPos,
		i,
		j,
		min;

	arr =[];
	input = args[0].split('\n');
	for (i = 1; i < input.length; i+=1){
		arr[i-1] = +input[i];
	}

	for (i = 0; i < arr.length; i += 1){
		min = arr[i];
		minPos = i;
		for (j = i+1; j < arr.length; j +=1){
			if (min > arr[j]) {
				min = arr[j];
				minPos = j;
			}
		}
		arr.splice(minPos, 1);
		arr.splice(i,0, min);
	}

	return arr.join('\n');
}