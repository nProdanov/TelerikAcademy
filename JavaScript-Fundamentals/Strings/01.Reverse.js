function solve(args) {
    var str = args[0];

    function reverse(str) {
        var reversed = '',
            i;

        for (i = 0; i < str.length; i += 1) {
            reversed = str[i] + reversed;
        }

        return reversed;
    }

    console.log(reverse(str));
}
