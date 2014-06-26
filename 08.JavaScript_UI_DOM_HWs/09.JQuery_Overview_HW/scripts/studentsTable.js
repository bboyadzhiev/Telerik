/// <reference path="jquery-2.1.1.js" />
(function () {
    var students = [{
        fName: "Peter",
        lName: "Ivanov",
        grade: 3
    }, {
        fName: "Milena",
        lName: "Grigorova",
        grade: 6
    },{
        fName: "Gergana",
        lName: "Borisova",
        grade: 12
    }, {
        fName: "Boyko",
        lName: "Petrov",
        grade: 7
    }];

    var $studentsTable = $('<table></table>').appendTo($('#studentsDiv'));
    $studentsTable.addClass('students-table');
   // var $studentsTableHeader = $('<thead></thead>').appendTo($studentsTable);
   //$('<tr><th>First Name</th><th>Last Name</th><th>Grade</th></tr>').appendTo($studentsTableHeader);
    $('<tr><th>First Name</th><th>Last Name</th><th>Grade</th></tr>').appendTo($('<thead></thead>').appendTo($studentsTable));
   var $studentsTableContent = $('<tbody></tbody>').appendTo($studentsTable);

    function insertStudents(students, $tableContentHolder) {
        for (var i = 0; i < students.length; i++) {
            $('<tr><td>' + students[i].fName
                + '</td><td>' + students[i].lName
                + '</td><td>' + students[i].grade
                + '</td></tr>').appendTo($tableContentHolder);
        }
    }

    insertStudents(students, $studentsTableContent);


}());