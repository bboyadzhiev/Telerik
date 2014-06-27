// <copyright file="Line.cs" company="bboyadzhiev">
//  Copyright bboyadzhiev
// </copyright>

namespace Tools
{
    using System;

    /// <summary>
    /// Defines a 2D-line
    /// </summary>
    public class Line
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class
        /// Uses two points
        /// </summary>
        /// <param name="firstPoint">The first point</param>
        /// <param name="secondPoint">The second point</param>
        public Line(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.Equals(secondPoint))
            {
                throw new ArgumentException("The points of the line cannot be with identical coordinates!");
            }

            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
        }

        /// <summary>
        /// Gets or sets first point of the line
        /// </summary>
        public Point FirstPoint { get; set; }

        /// <summary>
        /// Gets or sets the second point of the line
        /// </summary>
        public Point SecondPoint { get; set; }

        /// <summary>
        /// Gets the length of the line
        /// </summary>
        public double Length
        {
            get { return this.GetLength(); }
        }

        /// <summary>
        /// Gets a value indicating whether line is horizontal
        /// </summary>
        public bool IsHorizontal
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

        /// <summary>
        /// Gets a value indicating whether line is vertical
        /// </summary>
        public bool IsVertical
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

        /// <summary>
        /// Calculates the length of the line
        /// </summary>
        /// <returns>The length of the line</returns>
        private double GetLength()
        {
            double length =
                Math.Sqrt(((this.SecondPoint.X - this.FirstPoint.X) * (this.SecondPoint.X - this.FirstPoint.X))
                        + ((this.SecondPoint.Y - this.FirstPoint.Y) * (this.SecondPoint.Y - this.FirstPoint.Y)));

            return length;
        }
    }
}