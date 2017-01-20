function solve(args){
	var number = +args[0];
	for (var i = 0; i < 2; i+=1) {
		number/=10;
		
		number = Math.floor(number);
	}
	var thidDigit = number%10;
	var isSeven = thidDigit === 7;
	if (isSeven) {
		console.log(isSeven);
	}
	else{
	console.log(isSeven + ' ' + thidDigit);	
	}
}
