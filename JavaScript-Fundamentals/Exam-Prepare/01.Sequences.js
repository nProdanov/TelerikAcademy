function Solve(params) {
	var N = +params[0],
        arrNum,
	    answer,
        i;

answer = 1;
arrNum = [];
arrNum = params.map(Number);

for (i = 2; i <= N; i += 1) {
    if (arrNum[i] < arrNum[i-1]){
        answer +=1;
    }
}
console.log(answer);
}
