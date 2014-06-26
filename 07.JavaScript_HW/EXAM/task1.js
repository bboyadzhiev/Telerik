function solve(params) {
    var s = params[0],
        c1 = params[1], c2 = params[2], c3 = params[3],
        prices = [],
        goal = s;
        
    prices.push(c1);
    prices.push(c2);
    prices.push(c3);

    var answer = 0,
        currentSum = 0;
    // Your solution

    function remove(arr, element) {

        for (var i = arr.length - 1; i >= 0; i--) {
            if (arr[i] === element) {
                arr.splice(i, 1);
            }
        }
        return arr;
    }

    function Solver(goal, elements) {
        var mResults = [];
        var included = [];
        recursiveSolve(goal, 0, included, elements, 0);
    return mResults;
        //console.log(mResults);

    
}


    function recursiveSolve(goal, currentSum, included, notIncluded, startIndex) {
        for (var index = startIndex; index < notIncluded.length; index++) {
            var nextValue = notIncluded[index];
            console.log((currentSum + nextValue));
            if ((currentSum + nextValue) == goal) {
                var newResult = included.slice();
                newResult.push(nextValue);
                mResults.push(newResult);
                
            }   
            else {
                if ((currentSum + nextValue) < goal) {
                var nextIncluded = included.slice();
                nextIncluded.push(nextValue);
                var nextNotIncluded = notIncluded.slice();
                nextNotIncluded = remove(nextNotIncluded, nextValue);
                var asd = currentSum + nextValue;
                var si = startIndex++;
                recursiveSolve(goal, asd, nextIncluded, nextNotIncluded, si);
                }
            }
        }
    }
    console.log(goal);
    console.log(prices);
    console.log(Solver(goal, prices));
}

var args = [110, 13, 15, 17];

solve(args);