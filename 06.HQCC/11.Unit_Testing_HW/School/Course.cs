using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        public const int MAX_STUDENTS_PER_COURSE = 29;
        
        private List<Student> studentsInCourse = new List<Student>();

        public List<Student> StudentsInCourse
        {
            get { return studentsInCourse; }
        }

        private string couseName;

        public string CourseName
        {
            get { return couseName; }
            set { couseName = value; }
        }
        
        
        public void EnrollStudent(Student student){
            if (studentsInCourse.Contains(student))
            {
                throw new ArgumentException("Student has already enrolled in this course!");
            }
            if (studentsInCourse.Count >= MAX_STUDENTS_PER_COURSE)
            {
                throw new ArgumentException("Course is full!");
            }
            studentsInCourse.Add(student);
        }

        public void UnEnrollStudent(Student student)
        {
            if (!studentsInCourse.Contains(student))
            {
                throw new ArgumentException("Student was not enrolled in this course!");
            }
            studentsInCourse.Remove(student);
        }

        public Course(string name)
        {
            this.CourseName = name;
        }
    }
}
