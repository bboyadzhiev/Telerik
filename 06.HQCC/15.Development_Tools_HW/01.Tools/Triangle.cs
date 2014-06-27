// <copyright file="Triangle.cs" company="bboyadzhiev">
//  Copyright bboyadzhiev
// </copyright>

namespace Tools
{
    using System;

    /// <summary>
    /// Represents a Triangle
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class
        /// Creates a triangle by three given sizes with first side lying on the abscissa
        /// Second and third sides are lying above the abscissa
        /// </summary>
        /// <param name="a">The first size, defining a side, lying on the abscissa (0, a)</param>
        /// <param name="b">The second size</param>
        /// <param name="c">The third size</param>
        public Triangle(double a, double b, double c)
        {
            CanFormTriangle(a, b, c);

            double deltaX;
            deltaX = ((a * a) + (b * b) - (c * c)) / (2 * a);

            // Vertice C, dimension x
            double cx = a - deltaX;

            // Vertice C, dimension y
            double cy;
            cy = Math.Sqrt((b * b) - ((((a * a) + (b * b) - (c * c)) / (2 * a)) * (((a * a) + (b * b) - (c * c)) / (2 * a))));

            Point verticeA = new Point(0, 0);
            Point verticeB = new Point(a, 0);
            Point verticeC = new Point(cx, cy);

            this.FirstSide = new Line(verticeA, verticeB);
            this.SecondSide = new Line(verticeB, verticeC);
            this.ThirdSide = new Line(verticeA, verticeC);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class
        /// Creates a triangle by three given lines
        /// </summary>
        /// <param name="firstLine">The first line</param>
        /// <param name="secondLine">The second line</param>
        /// <param name="thirdLine">The third line</param>
        public Triangle(Line firstLine, Line secondLine, Line thirdLine)
        {
            CanFormTriangle(firstLine.Length, secondLine.Length, thirdLine.Length);

            this.FirstSide = firstLine;
            this.SecondSide = secondLine;
            this.ThirdSide = thirdLine;
        }

        /// <summary>
        /// Gets or sets the first side of the triangle
        /// </summary>
        public Line FirstSide { get; set; }

        /// <summary>
        /// Gets or sets  the second line of the triangle
        /// </summary>
        public Line SecondSide { get; set; }

        /// <summary>
        /// Gets or sets the third line of the triangle
        /// </summary>
        public Line ThirdSide { get; set; }

        /// <summary>
        /// Gets the triangle area
        /// </summary>
        public double Area
        {
            get { return this.GetTriangleArea(); }
        }

        /// <summary>
        /// Checks if three lines can form a triangle
        /// </summary>
        /// <param name="a">The first line</param>
        /// <param name="b">The second line</param>
        /// <param name="c">The third line</param>
        public static void CanFormTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("The size of all the sides should be greater than zero!");
            }

            if ((a + b <= c) || (a + c <= b) || (b + c <= a))
            {
                throw new ArgumentOutOfRangeException("Sizes cannot form a triangle!");
            }
        }

        /// <summary>
        /// Calculates the triangle area
        /// </summary>
        /// <returns>The area of the triangle</returns>
        private double GetTriangleArea()
        {
            double sideA = this.FirstSide.Length;
            double sideB = this.SecondSide.Length;
            double sideC = this.ThirdSide.Length;

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));
            return triangleArea;
        }
    }
}