// -------------- Array -------------------
Array.prototype.remove = function (element) {
    for (var i = this.length - 1; i >= 0; i--) {
        if (this[i] === element) {
            this.splice(i, 1);
        }
    }
}

function remove(arr, element) {

    for (var i = arr.length - 1; i >= 0; i--) {
        if (arr[i] === element) {
            arr.splice(i, 1);
        }
    }
    return arr;
}

function charArrToIntArr(charArr) {
    var intArr = [];

    for (var i = 0; i < charArr.length; i++) {
        intArr.push(parseInt(charArr[i]));
    }
    return intArr;
}

// -------------- String -------------------
String.prototype.reverse = function () {
    var gnirts = '';
    for (var char = this.length - 1; char >= 0; char--) {
        gnirts += this[char];
    }

    return gnirts;
}


// -------------- Object -------------------
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


Object.prototype.hasOwnProperty = function (property) {
    return typeof this[property] !== 'undefined';
};