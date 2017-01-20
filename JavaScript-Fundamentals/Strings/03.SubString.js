function solve(args) {
    var word = args[0];
    var text = args[1];
   
    var regex = new RegExp(word, 'gi');
    return (text.match(regex)).length;

}