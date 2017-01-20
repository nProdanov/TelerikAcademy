function solve(args) {
	var number,
		row,
		col,
		line;

	number = +args[0];

	for (row = 1; row <= number; row += 1) {
		line ='';
		for (col = row; col< row +number; col += 1) {
			if (col + 1 !== row + number) {
				line += col + ' ';
			}
			else {
				line += col;
			}
		}
		console.log(line);
	}

}