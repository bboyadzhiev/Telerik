using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTuningOptimization_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Stopwatch sw = new Stopwatch();
            int integerResult = 0;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                integerResult++;
            };
            sw.Stop();
            Console.WriteLine("Int: "+ sw.Elapsed);

            sw.Reset();
            long longResult = 0L;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                longResult++;
            };
            sw.Stop();
            Console.WriteLine("long : "+ sw.Elapsed);

            sw.Reset();
            float floatResult = 0f;
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                floatResult++;
            };
            sw.Stop();
            Console.WriteLine("float : " + sw.Elapsed);

            sw.Reset();
            decimal decimalResult = 0m;
            for (int i = 0; i < 100000; i++)
            {
                decimalResult++;
            };
            sw.Stop();
            Console.WriteLine("decimal : " + sw.Elapsed);
               
        }
    }
}
