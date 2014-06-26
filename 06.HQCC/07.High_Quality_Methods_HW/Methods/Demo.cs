using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numeric;
using School;
using Geometry;

namespace DemoSpace
{
    class Demo
    {
        static void Main()
        {
            //  Console.WriteLine( TriangleExtensions.CalcTriangleArea(3, 4, 5));


            Console.WriteLine(NumericMethods.DigitToString(5));

            Console.WriteLine(NumericMethods.GetMaxInteger(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine("-----------------------------");
            try
            {
                NumericMethods.PrintNumericValue("Lady Gaga", FormattingCode.FLOATING_POINT); // non-numeric value

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("-----------------------------");

            NumericMethods.PrintNumericValue("1.3", FormattingCode.FLOATING_POINT);
            NumericMethods.PrintNumericValue(1.3m, FormattingCode.FLOATING_POINT);
            NumericMethods.PrintNumericValue(1.3, FormattingCode.FLOATING_POINT);
            NumericMethods.PrintNumericValue(0.75, FormattingCode.PERCENT);
            NumericMethods.PrintNumericValue(2.30, FormattingCode.REAL_NUMBER);



            bool horizontal, vertical;
            Line line = new Line(new Point(3, -1), new Point(3, 2.5));

            Line line1 = new Line(new Point(0, 0), new Point(50, 0));
            Line line2 = new Line(new Point(50, 0), new Point(13, 15.2));
            Line line3 = new Line(new Point(15.2, 13), new Point(0, 0));

            //Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine(line.Length);

            //Console.WriteLine("Horizontal? " + horizontal);
            //Console.WriteLine("Vertical? " + vertical);
            Console.WriteLine("Horizontal? -> " + line.isHorizontal());
            Console.WriteLine("Vertical? -> " + line.isVertical());

            Console.WriteLine("Triangle 1");
            Triangle t = new Triangle(2, 4, 5);
            Console.WriteLine(t.ThirdSide.SecondPoint.X);
            Console.WriteLine(t.ThirdSide.SecondPoint.Y);

            Triangle t2 = new Triangle(2, 4, 3);
            Console.WriteLine(t2.ThirdSide.SecondPoint.X);
            Console.WriteLine(t2.ThirdSide.SecondPoint.Y);

            Triangle t3 = new Triangle(5, 4, 2);
            Console.WriteLine(t3.ThirdSide.SecondPoint.X);
            Console.WriteLine(t3.ThirdSide.SecondPoint.Y);

            Triangle t4 = new Triangle(line1, line2, line3);
            t4.ThirdSide.SecondPoint.X = 123;
            
            Console.WriteLine(t4.ThirdSide.SecondPoint.X);
            Console.WriteLine(t4.ThirdSide.FirstPoint.X);
            Console.WriteLine(t4.FirstSide.SecondPoint.X);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            try
            {
                Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }


        }
    }
}
