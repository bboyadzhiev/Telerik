define(function () {
    var Student;

    Student = (function () {
        function Student(studentInformation) { //constructor
            this.name = studentInformation.name;
            this.exam = studentInformation.exam;
            this.homework = studentInformation.homework;
            this.attendance = studentInformation.attendance;
            this.teamwork = studentInformation.teamwork;
            this.bonus = studentInformation.bonus;
        };

        Student.prototype.setTotalResult = function () {

        }

        Student.prototype.getTotalResult = function () {
            return tjis.totalResult;
        }
        return Student;
    }());

    return Student;
})