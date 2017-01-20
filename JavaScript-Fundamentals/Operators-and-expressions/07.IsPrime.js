



function solve (args) {
	var number = +args[0];
	if (number < 2) {
		return false;
	}

	for (var i = 2; i <= Math.sqrt(number); i+=1) {
		if (!(number % i )) {
			return false;
		}
	}

	return true;
}

console.log(solve([-3]));