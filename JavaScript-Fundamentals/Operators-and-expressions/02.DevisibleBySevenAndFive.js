	function solve(args) {
var someNumber = +[args];
var result = someNumber%35 === 0;
result += ' '+  someNumber;
console.log(result);
	}
solve(140);
