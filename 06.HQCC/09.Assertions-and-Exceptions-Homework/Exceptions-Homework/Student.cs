using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    public string FirstName { get; private set; } // setter set to private
    public string LastName { get; private set; } // setter set to private
    public IList<Exam> Exams { get; private set; }
    
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (firstName == null)
        {
            throw new ArgumentNullException("First name cannot be null!");
        }
        if (firstName.Length == 0)
        {
            throw new ArgumentNullException("First name cannot be zero-length!");
        }
        if (lastName == null)
        {
            throw new ArgumentNullException("First name cannot be null!");
        }
        if (lastName.Length == 0)
        {
            throw new ArgumentNullException("Last name cannot be zero-length!");
        }
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null || this.Exams.Count == 0)
        {
            throw new ArgumentNullException("Student had no exams yet!");
        }
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null || this.Exams.Count == 0)
        {
            throw new ArgumentNullException("Student had no exams yet!");
        }
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
