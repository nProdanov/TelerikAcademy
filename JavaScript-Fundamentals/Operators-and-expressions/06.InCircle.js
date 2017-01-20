//Write an expression that checks if given point P(x, y) is
// within a circle K({0,0}, 5). 
//{0,0} is the centre and 5 is the radius
function solve (args){
	var x = +args[0];
	var y = +args[1];
	var radius = 2;
	var distance = (x * x) + (y * y);
	var inCircle = distance <= (radius * radius);
	if (inCircle) {
		console.log('yes' + ' ' + Math.sqrt(distance).toFixed(2));	
	}
	else{
		console.log('no' + ' ' + Math.sqrt(distance).toFixed(2));	

	}
	
}
