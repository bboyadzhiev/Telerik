/// <reference path="libs/underscore.js" />
/// <reference path="Student.js" />
(function () {
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('libs/underscore.js');
    }

    //require(["libs/underscore", "Student"], function (_, Student) {

    var students = [],
        randomName,
        bestStudent,
        maleFirstNames = ['Joro', 'Stefan', 'Ivan', 'Dragan', 'Petar', 'Pesho', 'Gosho'],
        femaleFirstNames = ['Ani', 'Desi', 'Lili', 'Maria', 'Gergana', 'Iana', 'Iordanka', 'Angelina', 'Ioanna', 'Petia'],
        lastNames = ['Georgiev', 'Dimov', 'Angelov', 'Draganov', 'Petkanov', 'Popov', 'Stefanov'];

    function getRandomMarks(marksCount) {
        var i, marks = [];
        for (i = 0; i < marksCount; i++) {
            marks.push(getRandomInt(2, 6));
        }
        return marks.slice();
    }

    function getRandomName(isFemale, fNames, lNames) {
        var fName, lName;
        fName = fNames[getRandomInt(0, fNames.length - 1)];
        lName = lNames[getRandomInt(0, lNames.length - 1)];
        if (isFemale) {
            lName += 'a';
        }
        return {
            fName: fName,
            lName: lName
        }
    };

    function prepareStudents(studentsCount, marksCount, areFemale) {
        var randomStudents = [],
            randomName;
        for (var i = 0; i < studentsCount; i++) {
            if (areFemale) {
                randomName = getRandomName(true, femaleFirstNames, lastNames);
            } else {
                randomName = getRandomName(false, maleFirstNames, lastNames);
            }
            randomStudents.push(new Student(randomName.fName, randomName.lName, getRandomInt(7, 26), getRandomMarks(marksCount)));
        }
        return randomStudents.slice();
    }


    // Task 1
    function findWithFNameBeforeLName(studentsArray) {
        var filteredStudents = _.filter(studentsArray, function (student) {
            return student.getFName() < student.getLName();
        });
        return _.sortBy(filteredStudents, function (student) {
            return student.getFName();
        });
    }

    //Task 2
    function getFullNames18to24(studentsArray) {
        var filteredStudents = _.filter(studentsArray, function (student) {
            return (student.getAge() >= 18) && (student.getAge() <= 24);
        });
        return _.map(filteredStudents, function (student) {
            return {
                fName: student.getFName(),
                lName: student.getLName()
            }
        })
    }

    // Task 3
    function getStudentsWithHighestMarks(studentsArray) {
        var sortedStudents = _.sortBy(studentsArray, function (student) {
            // console.log(student.getFullName() +' ' + student.getMarksResult());
            return student.getMarksResult();
        })
        return _.last(sortedStudents);
    }

    // Task 7
    function getMostCommonFName(peopleArray) {
        var names, index, mostCommonFName
        names = _(peopleArray).chain()
            .countBy(function (person) {
              return person.getFName()
            })
          .value();
      
        index = _.max(names);
        mostCommonFName = _.invert(names);

        return mostCommonFName[index];
    }

    function getMostCommonLName(peopleArray) {
        var names, index, mostCommonLName
        names = _(peopleArray).chain()
            .countBy(function (person) {
                return person.getLName()
            })
          .value();

        index = _.max(names);
        mostCommonLName = _.invert(names);

        return mostCommonLName[index];
    }

    console.log('--- All the sudents ---');
    students = prepareStudents(5, 10, true).concat(prepareStudents(5, 10, false));
    console.dir(students);

    console.log('--- Task 1 - a method that from a given array of students finds all students whose  first name  --- ');
    console.log('--- is before its last name alphabetically. Print the students in descending order by full name --- ');
    console.dir(findWithFNameBeforeLName(students));

    console.log('--- Task 2 - a function that finds the first name and last name of all students with age between 18 and 24 --- ');
    console.dir(getFullNames18to24(students));

    console.log('--- Task 3 - a function that by a given array of students finds the student with highest marks');
    bestStudent = getStudentsWithHighestMarks(students)
    console.log('Best student: ' + bestStudent.getFullName() + ' result:' + bestStudent.getMarksResult());

    console.log('--- Task 7 - By an array of people find the most common first and last name ---');
    console.log('Most common first name is: ' + getMostCommonFName(students));
    console.log('Most common last name is: ' + getMostCommonLName(students));
}());