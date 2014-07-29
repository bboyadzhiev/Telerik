/// <reference path="jquery-2.1.1.js" />
(function () {
    var $errorMessage, $successMessage, addStudent, reloadStudents, resourceUrl;

    resourceUrl = 'http://localhost:3000/students';

    $successMessage = $('.messages .success');

    $errorMessage = $('.messages .error');

    addStudent = function (data) {
        return $.ajax({
            url: resourceUrl,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                $successMessage
                  .html('' + data.name + ' successfully added')
                  .show()
                  .fadeOut(2000);
                reloadStudents();
            },
            error: function (err) {
                $errorMessage
                  .html('Error happened: ' + err)
                  .show()
                  .fadeOut(2000);
            }
        });
    };



    deleteStudent = function (data) {
        return $.ajax({
            url: resourceUrl+'/'+data.id,
           //type: 'DELETE',
          //  data: JSON.stringify(data),
           // contentType: 'application/json',
            type: 'POST',
            data: {
                _method: 'delete'
            },
            success: function (data) {
                $successMessage
                  .html('Student successfully deleted')
                  .show()
                  .fadeOut(2000);
                reloadStudents();
            },
            error: function (err) {
                $errorMessage
                  .html('Error happened: ' + err)
                  .show()
                  .fadeOut(2000);
            }
        });
    }

    reloadStudents = function () {
        $.ajax({
            url: resourceUrl,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
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
                //
                $('.student-item').on('click', function () {
                    if (!confirm('Are you sure you want to delete this student?')) {
                         return;
                     }
                      var studentToDelete = {
                          id: $(this).attr('student-id')
                      }
                    deleteStudent(studentToDelete)
                        .then(function () {
                    $(this).remove();
                        })
                });
                //
            },
            error: function () {
                $errorMessage
                  .html("Error happened: " + err)
                  .show()
                  .fadeOut(2000);
            }
        });
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