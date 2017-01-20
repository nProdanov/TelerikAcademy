function solve (args) {
	var a = +args[0],
		b = +args[1],
		c = +args[2],
		xF,
		xS,
		d,
		result;

	d = (b*b) - (4*a*c);

	if (d) {
		if (d>0) {
			xF = (-b + Math.sqrt(d)) / (2 * a);
			xS = (-b - Math.sqrt(d)) / (2 * a);
			if (xF<xS) {
				result ='x1=' + xF.toFixed(2) + '; x2=' + xS.toFixed(2);
			}
			else{
				result ='x1=' + xS.toFixed(2) + '; x2=' + xF.toFixed(2);
			}
		}
		else{
			result = 'no real roots';
		}
	}
	else{
		xF = (-b) / (2 * a);
		result = 'x1=x2=' + xF.toFixed(2);
	}

	console.log(result);
}

