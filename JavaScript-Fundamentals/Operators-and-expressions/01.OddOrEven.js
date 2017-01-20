	function solve(args) {
    var someNumber =+args[0];
	var result= '';

	if (someNumber&1){
		result+='odd';
	}
	else{
		result+='even';
	}

	result +=' '+ someNumber;

	console.log(result);
	}
	
	solve([3]);		
	