function solve(args){
	var strArr,
		first,
		second,
		result;

	strArr = args[0].split('\n');
	first = strArr[0];
	second = strArr[1];
	result = '=';

	if (first>second) {
		result = '>';
	}
	else if (first < second){
		result = '<';
	}

	console.log(result);
}

