using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using StudentSystem.Models;

namespace StudentSystem.Services.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }

        public StudentInfo AdditionalInformation { get; set; }

        public static Expression<Func<Student, StudentModel>> FromStudentCFModel
        {
            get
            {
                return x => new StudentModel { Id = x.StudentIdentification, FirstName = x.FirstName, LastName = x.LastName, Level = x.Level };
            }
        }

        public Student CreateStudent()
        {
            return new Student { FirstName = this.FirstName, LastName = this.LastName, Level = this.Level, AdditionalInformation = new StudentInfo {  Address =  this.AdditionalInformation.Address, Email = this.AdditionalInformation.Email } };
        }

        public void UpdateStudent(Student student)
        {
            if (this.FirstName != null)
            {
                student.FirstName = this.FirstName;
            }
            if (this.LastName != null)
            {
                student.LastName = this.LastName;
            }
            if (this.AdditionalInformation != null)
            {
                student.AdditionalInformation = this.AdditionalInformation;
            }
            if (this.Level != null)
            {
                student.Level = this.Level;
            }
        }

    }
}