function solve(args) {
    var str = args[0],
        pat,
        match,
        result,
        start;
    start = 0;

    pat = new RegExp('(<a href=")(.*?)(">)(.*?)(<\/a>)' );
    match = pat.exec(str);
    result = '';
    while (match) {
        result = result + str.substring(start, match.index);
        result = '[' + match[4] + ']' + '(' + match[2] + ')';
        start = match.index + match[0].length;
        match = pat.exec(str);
    }
    console.log(str);


}


solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a<a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a><a href="www.devbg.org">our forum</a> training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);