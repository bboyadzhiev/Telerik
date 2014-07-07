/// <reference path="course.js" />
define(function () {
    var Student;
    Student = (function () {
        function Student(studentInfo) {
            this.name = studentInfo.name;
            this.exam = studentInfo.exam;
            this.homework = studentInfo.homework;
            this.attendance = studentInfo.attendance;
            this.teamwork = studentInfo.teamwork;
            this.bonus = studentInfo.bonus;

        };

        return Student;
    }());

    return Student;
})