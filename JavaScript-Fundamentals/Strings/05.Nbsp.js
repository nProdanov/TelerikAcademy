function  solve(args) {
    var str = args[0];

    str = str.replace(/ /g, '&nbsp;');

    console.log(str);
}

solve(['Hello World!']);