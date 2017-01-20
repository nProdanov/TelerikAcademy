/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(arr) {
	if (!arr) {
		throw new Error('Array is not defined');
	}

	if (!Array.isArray(arr)) {
		throw new Error('Argument is not an array');
	}

	if (!arr.length) {
		return null;
	}

	if (!arr.every(function (num) {
		return num == Number(num);
	})) {
		throw new Error('Every array element must be or convortable to a number');
	}

	return arr.reduce(function (a, b) {
		b = +b;
		return a + b;
	}, 0);
}

module.exports = sum;