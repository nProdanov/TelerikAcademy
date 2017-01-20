function solve(args) {
    var result,
    i,
    inBody;
    result = [];
    for (i = 0; i < args.length; i += 1) {
        if(args[i].match(/<body>/g)){
            if (!args[i].match(/<\/body>/g)) {
                inBody = true;     
            }
            result[i] = args[i].match(/>.*<\//g);           
        }
        
       
    }
}