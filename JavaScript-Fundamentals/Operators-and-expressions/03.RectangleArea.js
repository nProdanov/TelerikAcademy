function solve(args){
var width = +args[0];
var height = +args[1];
var area = width*height;
var perimeter = (2 * width) + (2 * height);
var result = area.toFixed(2) + ' ' + perimeter.toFixed(2);
console.log(result);
}
