/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(start, end) {
	var primes = [];
	if(start === undefined || end === undefined){
		throw new Error('Missing params');
	}

	if(isNumber(start) && isNumber(end)){
		start = +start;
		if (start < 2){
			start = 2;
		}
		end = +end;

		for (var i = start; i <= end; i += 1) {
			if(isPrime(i)){
				primes.push(i);
			}
		}
	}

	return primes;

	function isPrime(num){
		var end = Math.sqrt(num);
		for (var i = 2; i <= end; i += 1) {
			if(num % i === 0){
				return false;
			}
		}
		return true;
	}

	function isNumber(num){
		if(num == Number(num)){
			return true;
		}
		else{
			throw new Error('Range params must be or convertible to Number');			
		}
	}
}

module.exports = findPrimes;
