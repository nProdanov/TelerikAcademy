function solve(args){
	var first = +args[0],
		second = +args[1],
		third = +args[2],
		max;

	if (first > second) {
		if (second > third) {
			max =first;
		}
		else if(first > third) {
			max =first;
		}
		else{
			max = third;
		}
	}
	else{
		if (second > third) {
			max = second;
		}
		else{
			max = third;
		}

	}

	console.log(max);
}

