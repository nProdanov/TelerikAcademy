function solve(args) {
    var str = args[0],
    open,
    close,
    i;

    open = 0;
    close = 0;
    for (i = 0; i < str.length; i += 1) {
        if (str[i] === '(') {
            open +=1;
        }
        else if (str[i] === ')'){
            close +=1;
        }
    }
    if (open === close) {
        console.log('Correct');
    }
    else{
        console.log('Incorrect');
    }
}

