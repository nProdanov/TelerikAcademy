function solve (args) {
	var first = +args[0],
		second = +args[1],
		third = +args[2],
		result;

	if (first === 0 || second ===0 || third ===0) {
		result = 0;
	}
	else if(first < 0) {
		if (second < 0){
			if (third<0){
				result = '-';
			}
			else{
				result = '+';
			}
		}
		else{
			if (third < 0){
				result  = '+';
			}
			else{
				result = '-';
			}
		}
	}
	else{
		if (second <0){
			if (third <0) {
				result = '+';
			}
			else{
				result = '-';
			}
		}
		else{
			if (third < 0) {
				result = '-';
			}
			else{
				result = '+';
			}
		}
	}

	console.log(result);
}
