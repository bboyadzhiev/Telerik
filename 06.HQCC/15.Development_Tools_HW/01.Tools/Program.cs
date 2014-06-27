namespace Tools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Prints a menu to the Console
        /// </summary>
        public static void PrintMenu()
        {
            Console.WriteLine("Calculate area using: ");
            Console.WriteLine("1. The length of a side and an altitude to it");
            Console.WriteLine("2. The length of the three sides");
            Console.WriteLine("3. The length of two of the sides and the angle between them");
            Console.WriteLine();
            Console.Write("Choice: ");
        }

        /// <summary>
        /// Calculates the area of a triangle, using the method, specified by 'choice'
        /// </summary>
        /// <param name="choice">Specifies the method to be used to calculate the area</param>
        /// <returns>The calculate area</returns>
        public static double CalculateArea(byte choice)
        {
            double paramA = 0;
            double paramB = 0;
            double paramC = 0;
            float angle = 0;
            switch (choice)
            {
                case 1: Console.WriteLine("- Enter the side's length and altitude to it.");
                    Console.Write("Side length: ");
                    double.TryParse(Console.ReadLine(), out paramA);
                    Console.Write("Altitude: ");
                    double.TryParse(Console.ReadLine(), out paramB);
                    return Triangle.GetSurface(paramA, paramB);
                case 2: Console.WriteLine("- Ener the length of the three sides");
                    Console.Write("First side: ");
                    double.TryParse(Console.ReadLine(), out paramA);
                    Console.Write("Second side: ");
                    double.TryParse(Console.ReadLine(), out paramB);
                    Console.Write("Third side: ");
                    double.TryParse(Console.ReadLine(), out paramC);
                    return Triangle.GetSurface(paramA, paramB, paramC);
                case 3: Console.WriteLine("- Enter two sides and the angle between them");
                    Console.Write("First side: ");
                    double.TryParse(Console.ReadLine(), out paramA);
                    Console.Write("Second side: ");
                    double.TryParse(Console.ReadLine(), out paramB);
                    Console.Write("Angle: ");
                    float.TryParse(Console.ReadLine(), out angle);
                    angle = (float)(Math.PI * angle / 180.0);
                    return Triangle.GetSurface(paramA, paramB, angle);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Main entry point
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("--- Calculates a triangle's area by given parameters ---");
            PrintMenu();
            double area = 0;
            byte choice;
            byte.TryParse(Console.ReadLine(), out choice);
            if (choice != 0)
            {
                area = CalculateArea(choice);
                Console.WriteLine("The area of the triangle is: {0}", area);
            }
            else
            {
                Console.WriteLine("Incorrect choice!");
            }
        }
    }
}
