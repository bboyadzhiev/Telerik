namespace Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a Triangle
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// Calculates the surface of a triangle, based on 
        /// side and the altitude to it
        /// </summary>
        /// <param name="side">The length of the side</param>
        /// <param name="altitude">The length of the altitude</param>
        /// <returns>The area of the triangle</returns>
        public static double GetSurface(double side, double altitude)
        {
            return 0.5 * side * altitude;
        }

        /// <summary>
        /// Calculates the surface of a triangle, based on
        /// the lengths of its sides. Uses Heron's formula
        /// </summary>
        /// <param name="sideA">The length of the first side</param>
        /// <param name="sideB">The length of the second side</param>
        /// <param name="sideC">The length of the third side</param>
        /// <returns>The surface of the triangle</returns>
        public static double GetSurface(double sideA, double sideB, double sideC)
        {
            double p = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }

        /// <summary>
        /// Calculates the surface of a triangle, based on
        /// the lengths of two of its sides and the angle between them
        /// </summary>
        /// <param name="sideA">The length of the first side</param>
        /// <param name="sideB">The length of the second side</param>
        /// <param name="angle">The value of the angle between them</param>
        /// <returns>The surface of the triangle</returns>
        public static double GetSurface(double sideA, double sideB, float angle)
        {
            return (double)(0.5 * sideA * sideB * Math.Sin(angle));
        }
    }
}
