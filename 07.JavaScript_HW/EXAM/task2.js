function solve(args) {
    var fieldSize = args[0].split(" "),
        R = parseInt(fieldSize[0]),
        C = parseInt(fieldSize[1]);

    var instructField = new Array();

    for (var i = 0; i < R; i++) {
        var fieldString = args[i + 1];
        instructField[i] = new Array();
        for (var j = 0; j < C; j++) {
            instructField[i][j] = new Array (parseInt(fieldString[j]), true);
        }
    }

    var scoreField = new Array();
    for (var i = 0; i < R; i++) {
        scoreField[i] = new Array();
        for (var j = 0; j < C; j++) {
            scoreField[i][j] = Math.pow(2, i) - j;
        }

    }

    var path = 0, jumps = 0;
    var currentRow = parseInt(R-1), currentCol = parseInt(C-1);
    var sum = 0;
    // ------------------------------------------------------
    while (instructField[currentRow][currentCol][1]){
        instructField[currentRow][currentCol][1] = false;
        jumps++;
       // sum = sum + parseInt(scoreField[currentRow][currentCol]);
        var newRow = currentRow, newCol = currentCol;

        switch (instructField[currentRow][currentCol][0]) {
            case 1: newRow -= 2; newCol += 1; break;
            case 2: newRow -= 1; newCol += 2; break;
            case 3: newRow += 1; newCol += 2; break;
            case 4: newRow += 2; newCol += 1; break;
            case 5: newRow += 2; newCol -= 1; break;
            case 6: newRow += 1; newCol -= 2; break;
            case 7: newRow -= 1; newCol -= 2; break;
            case 8: newRow -= 2; newCol -= 1; break;
            default:
        }

        //console.log(parseInt(scoreField[currentRow][currentCol]));

        if (((newRow >= R ) || (newRow < 0)) || ((newCol >= C ) || (newCol < 0))) {
            sum += parseInt(scoreField[currentRow][currentCol]);
            //console.log('Go go Horsy! Collected' + sum + ' weeds');
            return 'Go go Horsy! Collected ' + sum + ' weeds';
        } else {
            sum += parseInt(scoreField[currentRow][currentCol]);
            currentRow = parseInt(newRow);
            currentCol = parseInt(newCol);
        }

    }

    return 'Sadly the horse is doomed in '+jumps+' jumps';
   // console.log(instructField);
   // console.log(scoreField);
}

var args = [
  '3 5',
  '54561',
  '43328',
  '52388',
];

args = [
  '3 5',
  '54361',
  '43326',
  '52188',
];


console.log( solve(args));