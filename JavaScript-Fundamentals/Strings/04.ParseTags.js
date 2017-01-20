function solve(args) {
    var str = args[0],
        strArr,
        inTag = false,
        tag = '',
        i,
        result = '',
        inUp,
        inLow,
        result;

        str = str.replace(/<upcase>/gi, ' <upcase> ');
        str = str.replace(/<\/upcase>/gi, ' <\/upcase> ');

        str = str.replace(/<lowcase>/gi, ' <lowcase> ');
        str = str.replace(/<\/lowcase>/gi, ' <\/lowcase> ');

        str = str.replace(/<orgcase>/gi, ' <orgcase> ');
        str = str.replace(/<\/orgcase>/gi, ' <\/orgcase> ');

result = '';
strArr = str.split([' ',]);
while(strArr.some(function (item) {
    return item.match(/<[A-Za-z]*>/);
})){
    for (i = 0; i < strArr.length; i += 1) {
        if (inTag) {
            if (inUp) {
                if (strArr[i].toLowerCase() === '<\/upcase>') {
                    strArr[i] = '';
                    inUp = false;
                    inTag = false;
                }
                else {
                    strArr[i] = strArr[i].toUpperCase();
                }
            }
            else if (inLow) {
                if (strArr[i].toLowerCase() === '<\/lowcase>') {
                    strArr[i] = '';
                    inLow = false;
                    inTag = false;
                }
                else {
                    strArr[i] = strArr[i].toLowerCase();
                }
            }
            else{
                if (strArr[i].toLowerCase() === '<\/orgcase>') {
                    strArr[i] = '';
                    inTag = false;
                }
            }
        }
        else {
            switch (strArr[i].toLowerCase()) {
                case '<upcase>':
                    inTag = true;
                    inUp = true;
                    strArr[i] = '';
                    continue;
                case '<lowcase>':
                    inTag = true;
                    inLow = true;
                    strArr[i] = '';
                    continue;
                case '<orgcase>':
                    inTag = true;
                    strArr[i] = '';
            }
        }
    }
}
    
    for (i = 0; i < strArr.length; i += 1) {
        if (strArr[i]) {
            if (strArr[i].length === 1 && strArr[i].match(/[.,!?:]/)) {
                result = result + strArr[i].trim();
            }
            else{
            result = result + ' ' + strArr[i].trim();

            }
        }
        
    }
    console.log(result);
}

solve([ 'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.' ]);