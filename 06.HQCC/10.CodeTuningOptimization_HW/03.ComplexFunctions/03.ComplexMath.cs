using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ComplexFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //SQRT
            Stopwatch sw = new Stopwatch();
            double doubleResult = 0d;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                doubleResult++;
                Math.Sqrt(doubleResult);
            };
            sw.Stop();
            Console.WriteLine("Sqrt double: " + sw.Elapsed);

            sw.Reset();
            float floatResult = 0f;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                floatResult++;
                Math.Sqrt(floatResult);
            };
            sw.Stop();
            Console.WriteLine("Sqrt float : " + sw.Elapsed);

            sw.Reset();
            decimal decimalResult = 0m;
            for (int i = 0; i < 100000; i++)
            {
                decimalResult++;
                Math.Sqrt((double)decimalResult);
            };
            sw.Stop();
            Console.WriteLine("Sqrt decimal : " + sw.Elapsed);

            //Log
            doubleResult = 0d;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                doubleResult++;
                Math.Log(doubleResult);
            };
            sw.Stop();
            Console.WriteLine("Log double: " + sw.Elapsed);

            sw.Reset();
            floatResult = 0f;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                floatResult++;
                Math.Log(floatResult);
            };
            sw.Stop();
            Console.WriteLine("Log float : " + sw.Elapsed);

            sw.Reset();
            decimalResult = 0m;
            for (int i = 0; i < 100000; i++)
            {
                decimalResult++;
                Math.Log((double)decimalResult);
            };
            sw.Stop();
            Console.WriteLine("Log decimal : " + sw.Elapsed);

            //sin
            doubleResult = 0d;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                doubleResult++;
                Math.Sin(doubleResult);
            };
            sw.Stop();
            Console.WriteLine("Sin double: " + sw.Elapsed);

            sw.Reset();
            floatResult = 0f;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                floatResult++;
                Math.Sin(floatResult);
            };
            sw.Stop();
            Console.WriteLine("Sin float : " + sw.Elapsed);

            sw.Reset();
            decimalResult = 0m;
            for (int i = 0; i < 100000; i++)
            {
                decimalResult++;
                Math.Sin((double)decimalResult);
            };
            sw.Stop();
            Console.WriteLine("Sin decimal : " + sw.Elapsed);
        }
    }
}
