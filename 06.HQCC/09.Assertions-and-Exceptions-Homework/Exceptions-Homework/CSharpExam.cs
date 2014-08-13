using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("Score cannot be nagative!");
        }
        if (score > 100)
        {
            throw new ArgumentOutOfRangeException("Score cannot be bigger than 100 points!");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        // error detection moved to constructor
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
