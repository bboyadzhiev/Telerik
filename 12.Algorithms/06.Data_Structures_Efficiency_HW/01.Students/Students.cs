using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01.Students
{
    internal class Students
    {
        private static void Main(string[] args)
        {
            var textFileName = "..\\..\\students.txt";
            var encoding = Encoding.GetEncoding("windows-1251");
            var reader = new StreamReader(textFileName, encoding);
            var courses = new SortedDictionary<string, List<string>>();
            using (reader)
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    line = line.Replace(" ", string.Empty);
                    var words = line.Split('|');
                    var course = words[2];
                    var studentName = words[0] + " " + words[1];
                    if (!courses.ContainsKey(course))
                    {
                        courses.Add(course, new List<string>());
                    }
                    courses[course].Add(studentName);

                    line = reader.ReadLine();
                }
            }

            foreach (var course in courses)
            {
                Console.Write(course.Key + ": ");
                foreach (var student in course.Value)
                {
                    Console.Write(student + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}