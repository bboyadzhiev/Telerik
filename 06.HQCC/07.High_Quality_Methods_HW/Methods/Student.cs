using System;

namespace School
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {

            DateTime firstDate;
            DateTime secondDate;
            //DateTime firstDate = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            // DateTime secondDate = DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
            if (DateTime.TryParse(this.OtherInfo.Substring(this.OtherInfo.Length - 10), out firstDate) 
                && DateTime.TryParse(other.OtherInfo.Substring(other.OtherInfo.Length - 10), out secondDate))
            {
                return firstDate < secondDate;
            }
            else
            {
                throw new ArgumentException("Date information colud not be found!");
            }
        }
    }
}
