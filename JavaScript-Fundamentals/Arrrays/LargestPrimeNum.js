function solve(args){
	var num,
	devisor,
	result,
	isPrime;

	num = +args[0];
	result =2;
	if (num <= 3) {
		result = num;
	}
	else {
		while(num !== 3){
			
			isPrime =true;
			for (devisor =2; devisor <= Math.sqrt(num); devisor +=1){
				if (num % devisor ===0 ) {
					isPrime =false;
					break;
				}
			}
			if (isPrime) {
				result = num;
				break;
			}
			num -=1;
		}
	}

	console.log(result);

}

solve(['26']);