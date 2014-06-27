// <copyright file="Point.cs" company="bboyadzhiev">
//  Copyright bboyadzhiev
// </copyright>

namespace Tools
{
    /// <summary>
    /// Defines a 2D-point
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class
        /// Defines a 2D-point by given coordinates
        /// </summary>
        /// <param name="x">The X-coordinate</param>
        /// <param name="y">The Y-coordinate</param>
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the X coordinate of the point
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets Y coordinate of the point
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Checks two points for equality by comparing their coordinates
        /// </summary>
        /// <param name="otherPoint">The other point to compare by</param>
        /// <returns>True if points coordinates are the same</returns>
        public bool Equals(Point otherPoint)
        {
            if (this.X == otherPoint.X && this.Y == otherPoint.Y)
            {
                return true;
            }

            return false;
        }
    }
}
