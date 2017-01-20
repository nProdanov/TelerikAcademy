function solve(args) {
    var text = args[0],
        offSet = +args[1],
        countLet,
        i,
        compress,
        count,
        encrypt,
        sum,
        product,
        oddCount,
        currDigit;

    // compressing
    countLet = text[0];
    count = 1;
    compress = '';
    if (text.length === 1) {
        compress += countLet;
    }
    for (i = 1; i < text.length; i += 1) {
        if (text[i] === countLet) {
            count += 1;
            if (i + 1 === text.length) {
                if (count > 2) {
                    compress += count + countLet;
                }
                else {
                    compress += countLet + countLet;
                }
            }
        }
        else {
            if (count > 2) {
                compress += count + countLet;
            }
            else if (count === 2) {
                compress += countLet + countLet;
            }
            else {
                compress += countLet;
            }
            count = 1;
            countLet = text[i];
            if (i + 1 === text.length) {
                compress += countLet;
            }
        }
    }

    // Encryption
    encrypt = '';
    for (i = 0; i < compress.length; i += 1) {
        if (!isNaN(compress[i])) {
            encrypt += compress[i];
        }
        else {
            encrypt += encryptChar(compress[i], offSet);
        }
    }

    //transform
    sum = 0;
    product = 1;
    oddCount = 0;
    for (i = 0; i < encrypt.length; i += 1) {
        currDigit = +encrypt[i];
        if(currDigit%2){
            oddCount +=1;
            product *= currDigit;
        }
        else{
            sum += currDigit;
        }
    }

    console.log(sum);
    if(oddCount){
        console.log(product);
    }
    else{
        console.log(0);
    }

    

    function encryptChar(letter, offSet) {
        var letCode,
            enLettCode;
        
        letCode = letter.charCodeAt(0);
        
        enLettCode = letCode - offSet;
        if (enLettCode < 97) {
            enLettCode += 26;
        }


        return letCode ^ enLettCode;

    }

    


}

solve([
    'aabbzzzzzzzzzz',
    '0'
]);