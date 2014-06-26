//-------- Task 1 ---------- 
function toEnglishString(int) {
    var a = "";

    switch (int % 10) {
        case 0: a = "zero"; break;
        case 1: a = "one"; break;
        case 2: a = "two"; break;
        case 3: a = "three"; break;
        case 4: a = "four"; break;
        case 5: a = "five"; break;
        case 6: a = "six"; break;
        case 7: a = "seven"; break;
        case 8: a = "eight"; break;
        case 9: a = "nine"; break;
        default: a = "Not an integer!"; break;
    }
    alert(a);
}

//-------- Task 2 ---------- 
function reverseDecimal(decimal) { // task2
    decimal = decimal.toString();
    var charArray = [],
        reversedDecimal = "";
    for (var char in decimal) {
        charArray.unshift(decimal[char]);
    }

    for (var char in charArray) {
        reversedDecimal += charArray[char];
    }

    alert(reversedDecimal);
}

//-------- Task 3 ---------- 
function findWord(word, text, isCaseSensitive) {
    var wordCount = 0,
        splittedText = text.split(word);

    switch (arguments.length) {
        case 1: alert("Not enough arguments!"); return;  break;
        case 2: isCaseSensitive = false; break;
    }

    var index = 0;
    if (isCaseSensitive) {
        var index = text.indexOf(word);
        while (index >= 0) {
            index = text.indexOf(word, index + 1);
            wordCount++;
        }
    } else {
        wordCount = splittedText.length;
    }
    alert("The word " + word + " was found " + wordCount +" times!");
}

//-------- Task 4 ---------- 
function divsCount() {
    alert("There are " + document.getElementsByTagName('div').length + " div elements on this page!");
}

//-------- Task 5 ---------- 
function enterArray(count) {
    var array = [];
    for (var index = 0; index < count; index++) {
        array.push(parseFloat(prompt('Enter element ' + index + ':', 0)));
    }
    return array;
}

function elementInArrayCount(element, array) {
    var count = 0;
    for (var elem in array) {
        if (array[elem] == element) {
            count++;
        }
    }
    return count;
}

function task5TestFunction() {
    var array = [1, 1, 3, 4, 1, 5, -1, -2, 1, 3, 4, 4];
    alert('Element -1: ' + elementInArrayCount(-1, array) + ' times!');
    alert('Element -2: ' + elementInArrayCount(-2, array) + ' times!');
    alert('Element 1: ' + elementInArrayCount(1, array) + ' times!');
    alert('Element 3: ' + elementInArrayCount(3, array) + ' times!');
    alert('Element 4: ' + elementInArrayCount(4, array) + ' times!');
}

//-------- Task 6 ---------- 
function printArray(array) {
    var res = "{" + array[0];
    for (var i = 1; i < array.length; i++) {
        res += ", " + array[i];
    }
    res += "}";
    return res;
}

function isBiggerThanTheNeighbours(position, array) {
    var pos = parseInt(position);
    if (pos <= (array.length - 2)) {
        if ((array[pos] > array[pos - 1])
            && (array[pos] > array[pos + 1]))
        {
            return true;
        }
    }
    return false;
}

function task6(size, position, outputElement) {
    var array = [],
        out = document.getElementById(outputElement);

    if (position <= size - 2) {
        array = enterArray(size);
        out.innerHTML = printArray(array);
        alert(
            'Element at position '
            + position
            + (isBiggerThanTheNeighbours(position, array) ? ' is bigger' : ' is not bigger')
            + ' than its neighbours'
        );
    }
    else {
        alert("Position is outside array boundaries - 2 ! Aborting...");
    }
}

//-------- Task 7 ---------- 

function task7(size, outputElement) {
    var array = [],
        out = document.getElementById(outputElement),
        position = -1;

    array = enterArray(size);
    out.innerHTML = printArray(array);

    for (var i = 1; i < array.length-2; i++) 
    {
        if (isBiggerThanTheNeighbours(i, array)) 
        {
            position = i;   
            break;          
        }
    }

    if (position > 0) {
        alert('Found element ' + array[position] + ' at position ' + position);
    }
    else {
        alert(position);
    }
}