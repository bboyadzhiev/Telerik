using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || problemsSolved > 10)
        {
            throw new ArgumentOutOfRangeException("Invalid number of solved problems, should be integer in [0..10] !");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        // ProblemsSolved < 0 is alredy checked in class constructor
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }

        // Assuming 2 .. 10 problems solved is excellent
        return new ExamResult(6, 2, 6, "Excellent result: all done.");
    }
}
