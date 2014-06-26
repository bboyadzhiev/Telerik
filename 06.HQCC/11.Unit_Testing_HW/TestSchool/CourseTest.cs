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
    public class CourseTest
    {
        [TestMethod]
        public void TestEnrollStudent()
        {
            School.School school = new School.School("n-to osnovno");
            Student pesho = school.CreateStudent("Pesho", 1, 10000);
            Course c = new Course("Math");
            c.EnrollStudent(pesho);

            bool found = false;

            foreach (var student in c.StudentsInCourse)
            {
                if (student.SSN == pesho.SSN)
                {
                    found = true;
                    break;
                }
            }
            Assert.AreEqual(found, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEnrollAgainStudent()
        {
            School.School school = new School.School("n-to osnovno");
            Student gosho = school.CreateStudent("Gosho", 2, 10001);

            Course c = new Course("Math");

            c.EnrollStudent(gosho);
            c.EnrollStudent(gosho);
        }

       [TestMethod]
       [ExpectedException(typeof(ArgumentException))]
       public void TestEnrollMoreThanMAXStudent()
       {
           School.School school = new School.School("n-to osnovno");
           Course c = new Course("Algebra");

           for (int i = 0; i < Course.MAX_STUDENTS_PER_COURSE + 2; i++)
           {
               school.CreateStudent("Agent Smith No."+"i", i+1, 10000 + i);
           }

           foreach (var student in school.Students)
           {
               c.EnrollStudent(student.Value);
           }
       }
    }
}
