function solve(args){
	var arr,
		input,
		count,
		max,
		maxNum,
		i;

	input = args[0].split('\n');
	arr = [];
	for (i = 1; i<input.length; i += 1){
		arr[i] = +input[i];
	}

	arr.sort();
	curr =1;
	max =1;
	maxNum=arr[0];

	for (i=0; i<arr.length - 1; i+=1){
			if (+arr[i] === +arr[i+1]){
				
				curr+=1;
				if (max < curr) {
					max = curr;
					maxNum = arr[i];
				}
			}
			else{
				
				curr =1;
			}
		}
	console.log(maxNum + ' (' + max + ' times)');


}

