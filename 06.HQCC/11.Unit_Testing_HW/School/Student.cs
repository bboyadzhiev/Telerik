using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        
        private string name;
        private int ssn;

        public int SSN
        {
            get { return ssn; }
            set {
                if (value <=0 )
                {
                    throw new ArgumentOutOfRangeException("SSN should be positive number");
                }
                ssn = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Student(string name, int ssn)
        {
            this.Name = name;
            this.SSN = ssn;
        }
    }
}
