/// <reference path="student.js" />
define(function () {
    var Course;

    Course = (function () {
        function Course(courseName, scoreFormula) {
            this._students = [];
            this._scoreformula = scoreFormula;
        };

        Course.prototype.addStudent = function (student) {
            this._students.push(student);
        };

        Course.prototype.calculateResults = function () {
        var self = this;
          for (var i = 0; i < this._students.length; i++) {
              this._students[i].totalScore = this._scoreformula(this._students[i]);
          };

        };

        Course.prototype.getStudents = function () {
            return JSON.stringify(this._students);
        };

        Course.prototype.getTopStudentsByExam = function (studentsCount) {
            return getSortedbyExam(this._students, studentsCount);
        };

        Course.prototype.getTopStudentsByTotalScore = function (studentsCount) {
            return getSortedbyTotalScore(this._students, studentsCount);
        };

        function getSortedbyExam(students, count) {
            students.sort(function (first, second) {
                return second.exam - first.exam;
            })
            return students.slice(0, count);
        };

        function getSortedbyTotalScore(students, count) {
            students.sort(function (first, second) {
                return second.totalScore - first.totalScore;
            })
            return students.slice(0, count);
        };

        return Course;
    }());


    return Course;
})