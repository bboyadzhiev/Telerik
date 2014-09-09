
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Northwind_DbContext
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //AstrogationPDFReport2.GenerateReport();
            //Console.WriteLine(sw.Elapsed);
            //sw.Restart();
            AstrogationPDFReport.GenerateReport();
            Console.WriteLine(sw.Elapsed);
        }

      
    }
}
