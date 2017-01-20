function solve(args) {
    var str,
        protocol,
        server,
        resource,
        match;

    str = args[0];
    match = /([a-zA-Z]+):\/\/(.*[.].[a-zA-Z]+)(\/.*)/g.exec(str);

    protocol = match[1];
    server = match[2];
    resource = match[3];

    console.log('protocol: ' + protocol);
    console.log('server: ' + server);
    console.log('resource: ' + resource);
}

function solveSecond(args) {
    var str = args[0],
        protocol,
        server,
        resource;

    var resultF = str.split('://');
    protocol = resultF[0];
    var resultS = resultF[1].split('/');
    server = resultS[0];
    var resultT = resultF[1].split(server);
    resource = resultT[1];

    console.log('protocol: ' + protocol);
    console.log('server: ' + server);
   console.log('resource: ' + resource);
    
}

solve(['http://telerikacademy.com/Courses/Courses/Details/239']);