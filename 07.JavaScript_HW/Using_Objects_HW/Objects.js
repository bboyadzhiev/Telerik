// ------------- some usefull methods --------
function enterArray(count) {
    var array = [];
    for (var index = 0; index < count; index++) {
        array.push(parseFloat(prompt('Enter element ' + index + ':', 0)));
    }
    return array;
}

function printArray(array) {
    var res = "{" + array[0];
    for (var i = 1; i < array.length; i++) {
        res += ", " + array[i];
    }
    res += "}";
    return res;
}

// -------------- Task 1 -------------------
function newPoint(x, y) {
    return {
        x: x,
        y: y,
        toString: function(){return '('+this.x + ', ' + this.y + ')'}
    };
}

function newLine(firstPoint, secondPoint) {
    return {
        firstPoint: newPoint(firstPoint.x, firstPoint.y),
        secondPoint: newPoint(secondPoint.x, secondPoint.y),
        length: function () { return distance(this.firstPoint, this.secondPoint); },
        toString: function() {return '['+this.firstPoint.toString() + ', ' +this.secondPoint.toString()+'], length: ' + this.length()}
        
    };
}

function distance(firstPoint, secondPoint) {
    var dx = parseFloat(firstPoint.x - secondPoint.x),
        dy = parseFloat(firstPoint.y - secondPoint.y);

    return Math.sqrt((dx * dx) + (dy * dy));
}

function canFormTriangle(firstLine, secondLine, thirdLine) {
    return (((firstLine.length() + secondLine.length()) > thirdLine.length())
        && ((firstLine.length() + thirdLine.length()) > secondLine.length())
        && ((secondLine.length() + thirdLine.length()) > firstLine.length()));
}

function Task1() {
    var p1 = newPoint(10, 10),
        p2 = newPoint(20, 15),
        p3 = newPoint(15, 25);

    var line1 = newLine(p1, p2),
        line2 = newLine(p2, p3),
        line3 = newLine(p3, p1);

    console.log('line1: ' + line1.toString());
    console.log('line2: ' + line2.toString());
    console.log('line3: ' + line3.toString());
    console.log('Testing lines if they can form a triangle: ')
    console.log(canFormTriangle(line1, line2, line3));

    console.log(' ');
    console.log('Adding a new far point and line to it')

    var farPoint = newPoint(50, 22),
        bigLine = newLine(farPoint, p1);

    console.log('bigLine: ' + bigLine.toString());
    console.log('Testing lines if line1, line2 & bigLine can form a triangle: ')
    console.log(canFormTriangle(line1, line2, bigLine));
}

// -------------- Task 2 -------------------
Array.prototype.remove = function (element) {
    for (var i = this.length - 1; i >= 0; i--) {
        if (this[i] === element) {
            this.splice(i, 1);
        }
    }
}

function task2Html() {
    var arr = enterArray(document.getElementById('task2ArraySizeTB').value);

    console.log('Before removal:');
    console.log(printArray(arr));
    
    arr.remove(parseInt(document.getElementById('task2ElementTB').value));
    console.log('After removal:');
    console.log(printArray(arr));
}

function Task2() {
    var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];

    console.log('Array before processing:');
    console.log(arr);

    arr.remove(1);
    console.log('Array afrter remove(1) :');
    console.log(arr);
}

// -------------- Task 3 -------------------
// deepExtend by Andrew Dupont 
Object.deepExtend = function (destination, source) {
    for (var property in source) {
        if (typeof source[property] === "object") {
            destination[property] = destination[property] || {};
            arguments.callee(destination[property], source[property]);
        } else {
            destination[property] = source[property];
        }
    }
    return destination;
};

function Task3() {
    var line1 = newLine(newPoint(0, 0), newPoint(10, 10));

    console.log('First point: ')
    console.log(line1.toString());
 
    var line2 = newLine(newPoint(0, 0), newPoint(0, 0));

    Object.deepExtend(line2, line1)
    console.log('New point: ')
    console.log(line2.toString());
}

// -------------- Task 4 -------------------
Object.prototype.hasOwnProperty = function(property) {
    return typeof this[property] !== 'undefined';
};

function hasProperty(obj, prop) {
    return obj.hasOwnProperty(prop)
}

function Task4() {
    var o = {}
    o.x = 5;

    console.log(('Chacking object for property x: '))
    console.log(hasProperty(o, 'x'));
}

// -------------- Task 5 -------------------
var persons = [
    { firstname : 'Gosho', lastname: 'Petrov', age: 32 }, 
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'Some', lastname: 'Body', age: 35 },
    { firstname: 'Hitar', lastname: 'Petrov', age: 35 }
];

function youngest(persons) {
    var youngest = 150,
        result = persons[0];
    for (var person = 0; person < persons.length; person++ ) {
        if (youngest > persons[person].age) {
            result = persons[person];
            youngest = persons[person].age;
        }
    }
    return result;
}


function Task5() {
    console.log('Persons');
    for (var person = 0; person < persons.length; person++) {
        console.log(persons[person].firstname + ' ' + persons[person].lastname +', age: '+ persons[person].age)
    }

    console.log();
    console.log('The youngest person is: ');
    var youngestPerson = youngest(persons);
    console.log(youngestPerson.firstname + ' ' + youngestPerson.lastname + ', age: ' + youngestPerson.age);
    
}



// -------------- Task 6 -------------------
function group(persons, criteria) {

    var resultArray = [];

    for (var p = 0; p < persons.length; p++) {
        var currentPerson = {};
        Object.deepExtend(currentPerson, persons[p]);

        switch (criteria) {
            case 'firstname':
                if (resultArray[persons[p].firstname]) {
                    resultArray[persons[p].firstname].push(currentPerson);
                } else {
                    resultArray[persons[p].firstname] = new Array(currentPerson);
                }
                break;
            case 'lastname':
                if (resultArray[persons[p].lastname]) {
                    resultArray[persons[p].lastname].push(currentPerson);
                } else {
                    resultArray[persons[p].lastname] = new Array(currentPerson);
                }
                break;
            case 'age':
                if (resultArray[persons[p].age] ) {
                    resultArray[persons[p].age].push(currentPerson);
                }
                else {
                    resultArray[persons[p].age] = new Array(currentPerson);
                }
                break;
        }
    }
    return resultArray;
}

function Task6() {
    console.log('Grouped by First Name');
    console.log(group(persons, 'firstname'));

    console.log();
    console.log('Grouped by Last Name');
    console.log(group(persons, 'lastname'));

    console.log();
    console.log('Grouped by Age');
    console.log(group(persons, 'age'));
    console.log();
    console.log('* "By Age" always has indexes [0 - maximum age] by default');
}

// -------------- NodeJS -------------------
    console.log('Task 1:');
    Task1();

    console.log();
    console.log('Task 2:');
    Task2();

    console.log();
    console.log('Task 3 - Deep copy of objects:');
    Task3();

    console.log();
    console.log('Task 4:');
    Task4();

    console.log();
    console.log('Task 5:');
    Task5();

    console.log();
    console.log('Task 6:');
    Task6();
