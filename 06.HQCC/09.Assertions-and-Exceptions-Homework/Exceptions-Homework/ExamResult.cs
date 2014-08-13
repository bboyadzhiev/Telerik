using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade cannot be negarive!");
        }
       // What about this? 
       // if (grade > 100)
       // {
       //     throw new ArgumentOutOfRangeException("Grade must be in the range [0..100]!");
       // }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade cannot be negarive!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("maxGrade cannot be smaller then minGrade!");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentException("There should be some comments!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
