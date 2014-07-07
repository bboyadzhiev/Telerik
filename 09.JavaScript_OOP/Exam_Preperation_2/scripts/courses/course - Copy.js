define(function () {
    var Course;

    Course = (function () {
        function Course(title, scoreFormula) { //scoreFormila is a delegate function
            this.title = titile;
            this._scoreFormula = scoreFormula;
            this._students = {};
        };

        Courese.prototype.addStudent = function (student) {
            this._students.push(student);
        };

        Course.prototype.calculateResults = function () {
            var self = this;
            this._students.forEach(function (student) {
                student.totalResult = self._scoreFormula(student);
            })
            };

        Course.prototype.getTopStudentsByExam = function (count) {
            return sortStudents(this._students, count, 'totalResult');
        };

        function sortStudents(students, count, sortBy) {
            students.sort(function (first, second) {
                return second(sortBy - first.sortBy);
            });
            return this.students.slice(0, count);
        };

        return Course;
    }());

    return Course;
})