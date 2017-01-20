function solve (args) {
	var numberStr = args[0],
		legth,
		result;

	function GetNumber (number) {
	if (number < 20) {
		switch (number) {
			case 11 : return 'Eleven';
			case 12 : return 'Twelve';
			case 13 : return 'Thirteen';
			case 14 : return 'Fourteen';
			case 15 : return 'Fifteen';
			case 16 : return 'Sixteen';
			case 17 : return 'Seventeen';
			case 18 : return 'Eighteen';
			case 19 : return 'Nineteen';
		}
	}
	if(number % 10) {
		return GetTents(Math.floor(number /10)) + ' ' + GetDigit(number%10).toLowerCase();

	}
	else {
		return GetTents(number / 10);
		
	}
}

function GetTents (number) {
	switch (number) {
			case 1 : return 'Ten';
			case 2 : return 'Twenty';
			case 3 : return 'Thirty';
			case 4 : return 'Fourty';
			case 5 : return 'Fifty';
			case 6 : return 'Sixty';
			case 7 : return 'Seventy';
			case 8 : return 'Eighty';
			case 9 : return 'Ninety';
		}

}

function GetDigit (digit) {
	switch (digit) {
		case 0 : return 'Zero'; 
		case 1 : return 'One'; 
		case 2 : return 'Two'; 
		case 3 : return 'Three'; 
		case 4 : return 'Four'; 
		case 5 : return 'Five';
		case 6 : return 'Six'; 
		case 7 : return 'Seven'; 
		case 8 : return 'Eight'; 
		case 9 : return 'Nine'; 
	}
}


	length = numberStr.length;
	switch (length) {
		case 1 : result = GetDigit(+numberStr); 
			break;	
		case 2 : result = GetNumber(+numberStr);
			break;
		case 3 :
		if (+numberStr%100) {
			result = GetDigit(Math.floor(+numberStr/100)) + ' hundred and ';
			if (numberStr % 100 >= 10) {
				result += GetNumber(+numberStr % 100).toLowerCase();
			}
			else{
				result += GetDigit(+numberStr%100).toLowerCase();
			}
	}
		else{
			result = GetDigit(+numberStr / 100) + ' hundred';

		}
	}

	console.log(result);
}



