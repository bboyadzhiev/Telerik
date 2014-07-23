/// <reference path="Person.js" />
var Student = (function () {

    function Student(fname, lname, age, marks) {
        var i,
            marksCount = marks.length;
        Person.call(this, fname, lname, age);
        for ( i = 0; i < marksCount; i++) {
            if (marks[i]<2 || marks[i]>6) {
                throw "Invalid marks!";
            }
        }
        this._marks = marks.slice();
    }

    Student.prototype = new Person();
    Student.prototype.getMarks = function () {
        var marks = this._marks.slice();
        return marks;
    };

    Student.prototype.getMarksResult = function () {
        var i,
            results = 0,
            marks;
        marks = this.getMarks();
        for (i = 0; i < marks.length; i++) {
            results += marks[i];
        }
        return results;
    };
    return Student;
}());