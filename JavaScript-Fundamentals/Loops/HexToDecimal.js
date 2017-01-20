function solve(args) {
	var hexStr,
		decNumber,
		length,
		currPos,
		pow,
		currSymbol, 
		result,
		i;

	hexStr = args[0];
	length = hexStr.length;
	pow = length -1;
	decNumber =0;


	for (currPos = 0; currPos < length; currPos +=1) {
		currSymbol = hexStr[currPos];
		decNumber += GetNumber(currSymbol) * Pow(pow);
		pow -=1;
	}

	function Pow(pow) {
		result = 1;
		for (i =1; i<=pow; i += 1) {
			result *= 16;
		}

		return result;
	}

	function GetNumber (symbol) {
		switch (symbol) {
			case '0' : return 0;
			case '1' : return 1;
			case '2' : return 2;
			case '3' : return 3;
			case '4' : return 4;
			case '5' : return 5;
			case '6' : return 6;
			case '7' : return 7;
			case '8' : return 8;
			case '9' : return 9;
			case 'A' : return 10;
			case 'B' : return 11;
			case 'C' : return 12;
			case 'D' : return 13;
			case 'E' : return 14;
			case 'F' : return 15;

		}
	}

	console.log(decNumber);
}

