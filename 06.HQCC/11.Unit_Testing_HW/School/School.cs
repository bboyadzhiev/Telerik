using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{


    public class School
    {
        private const int MIN_ID_NUMBER = 10000;
        private const int MAX_ID_NUMBER = 99999;

        private SortedDictionary<int, Student> students = new SortedDictionary<int, Student>();

        public SortedDictionary<int, Student> Students
        {
            get { return students; }
        }
        
        private IList<Course> courses;

        public IList<Course> Courses
        {
            get { return courses; }
            set
            {
                if (courses.Contains((Course)value))
                {
                    throw new ArgumentException("Course already added!");
                }
                courses = value;
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public bool IsSsnAvailable(Student student)
        {
            foreach (var st in students.Values)
            {
                if (st.SSN == student.SSN)
                {
                    return false;
                }
            }

            return true;
        }

        public Student CreateStudent(string name, int ssn, int id)
        {
            Student s = new Student(name, ssn);
            AddStudent(s, id);
            return s;
        }

        public void AddStudent(Student student, int id)
        {
            if (!IsIDAvailable(id, this))
            {
                throw new ArgumentException("Student already in school!");
            }

            if (!IsSsnAvailable(student))
            {
                throw new ArgumentException("Student with that SSN already exists!");
            }

            students.Add(id, student);
        }

        public void RemoveStudent(int id) // By ID
        {
            if (!students.ContainsKey(id))
            {
                throw new ArgumentException("Student with id[" + id + "] not found!");
            }
            students.Remove(id);
        }

        public void RemoveStudent(Student student) // By reference
        {
            if (!students.ContainsValue(student))
            {
                throw new ArgumentException("Student " + student.Name + " was not found at school!");
            }
            students.Remove((int)(from st in students where st.Value == student select st.Key).Single());
        }

        public static bool IsIDAvailable(int id, School school)
        {
            if (id > MAX_ID_NUMBER)
            {
                throw new ArgumentOutOfRangeException("Student ID number is above the allowed maximum [" + MAX_ID_NUMBER + "]!");
            }
            if (id < MIN_ID_NUMBER)
            {
                throw new ArgumentOutOfRangeException("Student ID number is below the allowed minimum [" + MIN_ID_NUMBER + "]!");
            }
            if (school.students.ContainsKey(id))
            {
                return false;
            }
            return true;
        }

        public int GetStudentSSN(Student student)
        {
            var result =
                from st in students
                where st.Value.SSN == student.SSN
                select st.Value.SSN;
            if (result.Count() == 0)
            {
                throw new ArgumentException("Student was not found at school!");
            }
            if (result.Count() > 1)
            {
                throw new ArgumentException("Multiple students with same SSN[" + student.SSN + "] found !!!");
            }
            return (int)result.Single();
        }

        public int GetStudentID(Student student)
        {
            var result =
                from st in students
                where st.Value.SSN == student.SSN
                select st.Key;
            if (result.Count() == 0)
            {
                throw new ArgumentException("Student was not found at school!");
            }
            if (result.Count() > 1)
            {
                throw new ArgumentException("Multiple students with same SSN[" + student.SSN + "] found !!!");
            }
            return (int)result.Single();
        }

        public School(List<Course> courses)
        {
            if (courses == null)
            {
                throw new ArgumentNullException("Courses cannot be null");
            }
            if (courses.Count < 1)
            {
                throw new ArgumentOutOfRangeException("List of courses cannot be empty");
            }
            this.courses = courses;
        }

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            this.Name = name;
            this.courses.Add(course);
        }
    }

}
