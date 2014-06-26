using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Point otherPoint)
        {
            if (this.X == otherPoint.X && this.Y == otherPoint.Y)
            {
                return true;
            }
            return false;
        }
    }

    public class Line
    {
        public Point FirstPoint { get; set; }

        public Point SecondPoint { get; set; }

        public double Length
        {
            get { return this.GetLength(); }
        }

        public bool isHorizontal
        {
            get
            {
                if (this.Length != 0)
                {
                    return this.FirstPoint.Y == this.SecondPoint.Y;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isVertical
        {
            get
            {
                if (this.Length != 0)
                {
                    return this.FirstPoint.X == this.SecondPoint.X;
                }
                else
                {
                    return false;
                }
            }
        }

        public Line(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.Equals(secondPoint))
            {
                throw new ArgumentException("The points of the line cannot be with identical coordinates!");
            }

            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
        }

        double GetLength()
        {
            double length =
                Math.Sqrt((this.SecondPoint.X - this.FirstPoint.X) * (this.SecondPoint.X - this.FirstPoint.X)
                        + (this.SecondPoint.Y - this.FirstPoint.Y) * (this.SecondPoint.Y - this.FirstPoint.Y));

            return length;
        }
    }

    public class Triangle
    {
        public Line FirstSide { get; set; }
        public Line SecondSide { get; set; }
        public Line ThirdSide { get; set; }


        public double Area
        {
            get { return this.GetTriangleArea(); }
        }

        /// <summary>
        /// Creates a triangle by three given sizes with first side lying on the abcissa
        /// Second and third sides are lying above the abscissa
        /// </summary>
        /// <param name="a">The first size, defining a side, lying on the abcissa (0, a)</param>
        /// <param name="b">The second size</param>
        /// <param name="c">The third size</param>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("The size of all the sides should be greater than zero!");
            }

            if ((a + b <= c) || (a + c <= b) || (b + c <= a))
            {
                throw new ArgumentOutOfRangeException("Sizes cannot form a triangle!");
            }

            double deltaX;
            deltaX = (a * a + b * b - c * c) / (2 * a);

            //Vertice C, dimension x
            double Cx = a - deltaX;

            //Vertice C, dimension y
            double Cy;
            Cy = Math.Sqrt(b * b - ((a * a + b * b - c * c) / (2 * a)) * ((a * a + b * b - c * c) / (2 * a)));

            Point verticeA = new Point(0, 0);
            Point verticeB = new Point(a, 0);
            Point verticeC = new Point(Cx, Cy);

            this.FirstSide = new Line(verticeA, verticeB);
            this.SecondSide = new Line(verticeB, verticeC);
            this.ThirdSide = new Line(verticeA, verticeC);
        }


        /// <summary>
        /// Creates a triangle by three given lines
        /// </summary>
        /// <param name="firstLine"></param>
        /// <param name="secondLine"></param>
        /// <param name="thirdLine"></param>
        public Triangle(Line firstLine, Line secondLine, Line thirdLine)
        {
            this.FirstSide = firstLine;
            this.SecondSide = secondLine;
            this.ThirdSide = thirdLine;
        }

        double GetTriangleArea()
        {
            double sideA = this.FirstSide.Length;
            double sideB = this.SecondSide.Length;
            double sideC = this.ThirdSide.Length;

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));
            return triangleArea;
        }
    }

    public static class GeometryExtensions
    {
        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            double length =
                Math.Sqrt((secondPoint.X - firstPoint.X) * (secondPoint.X - firstPoint.X)
                        + (secondPoint.Y - firstPoint.Y) * (secondPoint.Y - firstPoint.Y));

            return length;
        }

        public static bool isVertical(this Line line)
        {
            if (line.Length != 0)
            {
                return line.FirstPoint.X == line.SecondPoint.X;
            }
            else
            {
                return false;
            }
        }

        public static bool isHorizontal(this Line line)
        {
            if (line.Length != 0)
            {
                return (line.FirstPoint.Y == line.SecondPoint.Y);
            }
            else
            {
                return false;
            }
        }

        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive!");
            }

            if ((sideA + sideB <= sideC) || (sideA + sideC <= sideB) || (sideB + sideC <= sideA))
            {
                throw new ArgumentOutOfRangeException("Sides cannot form a triangle!");
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));
            return triangleArea;
        }
    }
}
