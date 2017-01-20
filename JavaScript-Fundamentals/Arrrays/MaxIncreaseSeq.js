function solve(args){
	var arr,
		n,
		curr,
		max,
		i;
	if (+args[0] === 0) {
		max =0;
	}
	else{
	curr =1;
	max =1;
	arr = args[0].split('\n');
		for (i=1; i<arr.length - 1; i+=1){
			if (+arr[i] <= +arr[i+1]){
				curr+=1;
				if (max < curr) {
					max = curr;
				}
			}
			else{
				
				curr =1;
			}
		}
	}
	console.log(max);
}

