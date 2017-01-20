function solve (args){
	var x = +args[0];
	var y = +args[1];
	var radius = 1.5;
	var distance = Math.pow(Math.abs((x - 1)),2) + Math.pow(Math.abs((y - 1)),2);
	var inCircle = distance <= (radius * radius);
	var result='';
	if (inCircle) {
		result +='inside circle ';	
	}
	else{
		result +='outside circle ';	
	}
	if ((x>=-1&&x<=5)&&(y>=-1&&y<=1)) {
		result +='inside rectangle';
	}
	else{
		result +='outside rectangle';
	}
console.log(result);
	
}





