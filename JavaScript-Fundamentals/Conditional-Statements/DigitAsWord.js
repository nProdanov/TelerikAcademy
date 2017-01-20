function solve(args) {
	var digit = +args[0],
		digitStr;

	switch(digit){
		case 0 : digitStr = 'zero'; break;
		case 1 : digitStr = 'one'; break;
		case 2 : digitStr = 'two'; break;
		case 3 : digitStr = 'three'; break;
		case 4 : digitStr = 'four'; break;
		case 5 : digitStr = 'five'; break;
		case 6 : digitStr = 'six'; break;
		case 7 : digitStr = 'seven'; break;
		case 8 : digitStr = 'eight'; break;
		case 9 : digitStr = 'nine'; break;
		default : digitStr = 'not a digit';
	}

	console.log(digitStr);
}
