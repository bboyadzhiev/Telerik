/// <reference path="httpMethods.js" />
/// <reference path="jquery-2.1.1.js" />
(function () {
    var $errorMessage, $successMessage, addStudent, reloadStudents, resourceUrl;

    resourceUrl = 'http://localhost:3000/students';

    $successMessage = $('.messages .success');

    $errorMessage = $('.messages .error');

    reloadStudents = function () {
        var data = httpRequestsModule.getJSON(resourceUrl)
            .done(function (data) {
                var student, $studentsList, i, len;
                $studentsList = $('<ul/>').addClass('students-list');
                for (i = 0, len = data.students.length; i < len; i++) {
                    student = data.students[i];
                    $('<li />')
                      .addClass('student-item')
                        .attr('student-id', student.id)
                      .append($('<strong /> ')
                        .html(student.name))
                      .append($('<span />')
                        .html(student.grade))
                      .appendTo($studentsList);
                }
                $('#students-container').html($studentsList);
            })
        .fail(function (err) {
            $errorMessage
              .html("Error happened: " + err)
              .show()
              .fadeOut(2000);
        })
    };

    addStudent = function (data) {
        httpRequestsModule.postJSON(resourceUrl, data)
        .done(function (data) {
            $successMessage
              .html('' + data.name + ' successfully added')
              .show()
              .fadeOut(2000);
            reloadStudents();
        })
           .fail(function (err) {
               $errorMessage
                 .html('Error happened: ' + err)
                 .show()
                 .fadeOut(2000);
           })
    };

    $(function () {
        reloadStudents();
        $('#btn-add-student').on('click', function () {
            var student;
            student = {
                name: $('#tb-name').val(),
                grade: $('#tb-grade').val()
            };
            addStudent(student);
        });
    });
}).call(this);