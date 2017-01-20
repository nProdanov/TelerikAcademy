function solve (args) {
	var number,
		result,
		i;
	number = +args[0];
	result = '';
	for (i = 1; i <= number; i +=1){
		if (i + 1 > number) {
			result += i;
		}
		else{
			result += i + ' ';
		}
	}

	console.log(result);

}
