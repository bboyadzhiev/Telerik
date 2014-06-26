using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Lab = null;
        }

        

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse {");
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
