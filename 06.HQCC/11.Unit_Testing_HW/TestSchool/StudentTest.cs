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
    }
}
