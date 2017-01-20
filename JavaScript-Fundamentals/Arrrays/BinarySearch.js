function solve (args) {
	var inputArr,
		arr,
		lF,
		i,
		left,
		right,
		curr,
		pos,
		length,
		d,
		count;

	inputArr = args[0].split('\n');
	arr = [];
	lF = +inputArr[inputArr.length-1];

	for (i = 0; i < inputArr.length-1; i +=1){
		arr[i] = +inputArr[i+1];
	}

	length = arr.length;
	
	pos = -1;
	left = 0;
	right = length-1;
	count =0;
	


	while (count < length/2) {
		count +=1;
		d = left + Math.floor((right - left)/2);
		
		curr = arr[d];

		if (curr === lF) {
			pos = d;
			break;
		}

		if (lF < curr) {
			right = d;
			continue;
		}

		if (lF > curr) {
			left = d;
			continue;
		}

	}
	console.log(pos);
}





