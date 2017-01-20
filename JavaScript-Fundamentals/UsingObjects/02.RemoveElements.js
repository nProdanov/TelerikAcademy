'use strict';
function solve(args) {
    var i;
    Array.prototype.remove = function (rem) {
        var i,
            len,
            arr;
        arr = [];
        for (i = 0, len = this.length; i < len; i += 1) {
            if (this[i] !== rem) {
                arr.push(this[i]);
            }
        }
        
        return arr;
    };

    args.remove(args[0]);
    console.log(args.remove(args[0]).join('\n'));
}
