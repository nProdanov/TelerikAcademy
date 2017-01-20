'use strict';
function solve(args) {
    let obj = args[0];
    let str = args[1];

    obj = JSON.parse(obj);


    for (var key in obj) {
        let pat = new RegExp(('#{' + key + '}'), 'g');
        str = str.replace(pat, obj[key]);
    }
    console.log(str);
}