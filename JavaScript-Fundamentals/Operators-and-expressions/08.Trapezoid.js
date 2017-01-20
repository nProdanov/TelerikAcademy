function solve (args) {
	var sideA = +args[0];
	var sideB = +args[1];
	var heigth = +args[2];

	var area = ((sideA + sideB)/2) * heigth;

	return area.toFixed(7);
}

console.log(solve([5,7,12]));