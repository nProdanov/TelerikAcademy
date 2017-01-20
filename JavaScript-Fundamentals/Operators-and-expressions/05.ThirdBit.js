function solve(args){
	var number = +args[0];
	number >>=3;
	var mask =1;
	console.log((number&mask==1)+0);
}

solve([1024]);