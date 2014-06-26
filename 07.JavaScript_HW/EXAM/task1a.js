function solve(params) {
    var s = params[0], c1 = params[1], c2 = params[2], c3 = params[3];
    var answer = 0;
    // Your solution here

    var tempI = 0, tempJ = 0, tempK = 0;
    var spent = [];

    for (var i = 0; i <= parseInt(s / c1) ; i++) {
        tempI = i * c1;
        //console.log(parseInt(s / c1));
        for (var j = 0; j <= parseInt(s / c2) ; j++) {
            tempJ = j * c2;
            //console.log(tempJ);
            for (var k = 0; k <= parseInt(s/ c3); k++) {
                tempK = k * c3;
               // console.log(tempK);
                spent.push(tempI + tempJ + tempK);
            }

        }
    }

    //console.log(spent);

    for (var i = 0; i < spent.length; i++) {
        //console.log(spent[i]);
        if (( spent[i] > answer) && (spent[i] <= s)){
            answer = spent[i];
        }
    }

    console.log(answer);
}

//var args = [110, 13, 15, 17];

var args = [110,
19,
29,
39];

solve(args);