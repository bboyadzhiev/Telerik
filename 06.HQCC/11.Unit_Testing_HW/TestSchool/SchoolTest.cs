using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestStudentsAssignment()
        {
            School.School school = new School.School("n-to osnovno");
            List<Student> students = new List<Student>(){
            new Student("Pesho",1),
            new Student("Gosho", 2),
            new Student("Mariika", 3),
            new Student("Tosho", 4)
            };
            int id = 10000;

            foreach (var student in students)
            {
                school.AddStudent(student, id);
                id++;
            }
            
            Assert.AreEqual(school.GetStudentSSN(students[0]), 1);
            Assert.AreEqual(school.GetStudentID(students.Last()), 10003);
        }

        [TestMethod]
        public void TestStudentsCreation()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 1, 10000);
            Student gosho = school.CreateStudent("Gosho", 2, 10001);
            Assert.AreNotEqual(pesho.SSN, gosho.SSN);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentsWithSameID()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 1, 10001);
            Student gosho = school.CreateStudent("Gosho", 2, 10001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentsWithSameSSN()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 2, 10001);
            Student gosho = school.CreateStudent("Gosho", 2, 10002);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddStudentTwice()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 2, 10001);
            school.AddStudent(pesho, 10002);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIDOutOfMinimumRange()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 2, 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIDOutOfMaximumRange()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 2, 100000);
        }

        [TestMethod]
        public void TestGetStudentByID()
        {
            School.School school = new School.School("n-to osnovno");
            var id = 10000;
            Student pesho = school.CreateStudent("Pesho", 2, id);

            Assert.AreEqual(school.GetStudentID(pesho), id);
        }

        [TestMethod]
        public void TestGetStudentBySSN()
        {
            School.School school = new School.School("n-to osnovno");
            var ssn = 123;
            Student pesho = school.CreateStudent("Pesho", ssn, 10005);

            Assert.AreEqual(school.GetStudentSSN(pesho), ssn);
        }

        [TestMethod]
        public void TestIsNewStudent()
        {
            School.School school = new School.School("n-to osnovno");
            var assignedID = 10023;
            Student assignedStudent = school.CreateStudent("Pesho", 111, assignedID);

            var unassignedID = 99000;
            Student unassignedStudent = new Student("Gosho", 222);

            Assert.AreEqual(school.IsSsnAvailable(assignedStudent), false);
            Assert.AreEqual(School.School.IsIDAvailable(assignedID, school), false);

            Assert.AreEqual(school.IsSsnAvailable(unassignedStudent), true);

            Assert.AreNotEqual(School.School.IsIDAvailable(unassignedID, school), false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemovingStudenByReference()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 2, 10002);
            school.RemoveStudent(pesho);

            //expecting "Student not found" exception
            school.GetStudentID(pesho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemovingStudenByID()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 2, 10002);
            school.RemoveStudent(10002);

            //expecting "Student not found" exception
            school.GetStudentID(pesho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemovingInvalidStudenByReference()
        {
            School.School school = new School.School("n-to osnovno");
            Student unassignedStudent = new Student("Gosho", 222);
            school.RemoveStudent(unassignedStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemovingInvalidStudenByID()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 2, 10002);
            school.RemoveStudent(10008);
        }



        [TestMethod]
        public void TestAddingCourses()
        {
            School.School school = new School.School("n-to osnovno");
            Course course = new Course("math");
            school.AddCourse(course);

            Assert.AreEqual(school.Courses[0].CourseName, course.CourseName);
        }

        [TestMethod]
        public void TestSchoolName()
        {
            var schoolName = "n-to osnovno";
            School.School school = new School.School(schoolName);
            Course course = new Course("math");

            Assert.AreEqual(school.Name, schoolName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddingSameCourse()
        {
            School.School school = new School.School("n-to osnovno");
            Course course = new Course("math");
            school.AddCourse(course);
            school.AddCourse(course);
        }
    }
}
