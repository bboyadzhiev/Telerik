using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;
using System;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestStudentConstuctor()
        {
            string name = "Pesho";
            int ssn = 12345;
            Student student = new Student(name, ssn);
            Assert.AreEqual(student.Name, "Pesho");
            Assert.AreEqual(student.SSN, ssn);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentNegativeSSN()
        {
            string name = "Pesho";
            int ssn = -12345;
            Student student = new Student(name, ssn);
        }
    }
}