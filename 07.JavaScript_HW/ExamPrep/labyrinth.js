function Solve(args) {
    var labSize = args[0].split(" "),
        N = parseInt(labSize[0]),
        M = parseInt(labSize[1]),
        startPos = args[1].split(" "),
        R = parseInt(startPos[0]), C = parseInt(startPos[1]),
        labLength = 0;

    var labyrinth = new Array();

    for (var i = 0; i < N; i++) {
        var labRowString = args[i + 2];
        labyrinth[i] = new Array();
        for (var j = 0; j < M; j++) {
            labLength++;
            labyrinth[i][j] = new Array(labRowString[j], true, labLength);
        }
    }

    var path = 0;
    var currentRow = parseInt(R), currentCol = parseInt(C);
    var visitedCount = 0;
   // var lastRow = 0, lastCol = 0;

    while (labyrinth[currentRow][currentCol][1]) {
        labyrinth[currentRow][currentCol][1] = false;
        visitedCount++;
      //  lastRow = currentRow;
      //  lastCol = currentCol;
       var newRow = 0, newCol = 0;
       switch (labyrinth[currentRow][currentCol][0]) {
           case 'l': newRow = currentRow; newCol = currentCol - 1; break;
           case 'r': newRow = currentRow; newCol = currentCol + 1; break;
           case 'u': newRow = currentRow - 1; newCol = currentCol; break;
           case 'd': newRow = currentRow + 1; newCol = currentCol; break;
           default:
       }
     
       if (((newRow >= N) || (newRow < 0)) || ((newCol >= M) || (newCol < 0))) {
           path += parseInt(labyrinth[currentRow][currentCol][2]);
           return 'out ' + path;
       } else {
           path += parseInt(labyrinth[currentRow][currentCol][2]);
           currentRow = parseInt(newRow);
           currentCol = parseInt(newCol);
       }
    }

    return 'lost ' + visitedCount;
}


var args1 = [
 "3 4",
 "1 3",
 "lrrd",
 "dlll",
 "rddd"];

args2 = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"];

args3 = [
 "10 16",
 "5 6",
 "rrrrrrrdrrrrrrrd",
 "rludulrdrludulrd",
 "lurlddudlurlddud",
 "urrrldudurrrldud",
 "ulllllldulllllll",
 "rrrrrrrdrrrrrrrd",
 "rludulrdrludulrd",
 "lurlddulllrlddud",
 "urrrldudurrrldud",
 "ulllllllulllllll"

]


console.log(Solve(args1));
console.log(Solve(args2));
console.log(Solve(args3));
