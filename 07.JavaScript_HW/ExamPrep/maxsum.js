function Solve(params) {
    var N = parseInt(params[0]);
    // Your code here...
    var maxSum = -2000000000;
    var localSum = 0;
    for (var i = 1; i <= N; i++) {

        for (var j = i; j <= N; j++) {
            localSum = 0;
            for (var k = i; k <= j; k++) {
                localSum += params[k];
            }

            if (localSum > maxSum) {
                maxSum = localSum;
            }
        }
    }

    return maxSum;

}

var input = [
 8,
1,
6,
-9,
4,
4,
-2,
10,
-1
];

console.log(Solve(input));
