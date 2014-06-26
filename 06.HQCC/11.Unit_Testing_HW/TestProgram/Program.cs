using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School;
using TestSchool;


namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolTest schoolTest = new SchoolTest();
            schoolTest.TestStudentsCreation();
            schoolTest.TestStudentsAssignment();
            
            schoolTest.TestGetStudentByID();
            schoolTest.TestGetStudentBySSN();
            schoolTest.TestIsNewStudent();

            schoolTest.TestAddingCourses();

            //[Throwing Exceptions as expected]
            //schoolTest.TestAddStudentTwice();
            //schoolTest.TestStudentsWithSameID();
            //schoolTest.TestStudentsWithSameSSN();
            //schoolTest.TestIDOutOfMinimumRange();
            //schoolTest.TestIDOutOfMaximumRange();

            CourseTest courseTest = new CourseTest();
            //[Throwing Exceptions as expected]
            //courseTest.TestEnrollMoreThanMAXStudent();
            //courseTest.TestEnrollAgainStudent();
        }
    }
}
