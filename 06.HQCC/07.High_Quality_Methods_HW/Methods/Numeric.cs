using System;

namespace Numeric
{
    public enum FormattingCode
    {
        FLOATING_POINT = 1,
        PERCENT = 2,
        REAL_NUMBER = 3
    };

    public class NumericMethods
    {
       

        public static string DigitToString(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("Invalid number!");
            }
        }

        public static int GetMaxInteger(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Not enough arguments!");
            }

            int maxInt = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxInt)
                {
                    maxInt = elements[i];
                }
            }
            return maxInt;
        }

        public static void PrintNumericValue(double number, FormattingCode format)
        {
            switch (format)
            {
                case FormattingCode.FLOATING_POINT: Console.WriteLine("{0:f2}", number); break;
                case FormattingCode.PERCENT: Console.WriteLine("{0:p0}", number); break;
                case FormattingCode.REAL_NUMBER: Console.WriteLine("{0,8}", number); break;
                default: throw new ArgumentException("Format not recognized!");
            }
        }

        // In case "object number" is obligatory, this implementation should be used
        public static void PrintNumericValue(object numeric, FormattingCode format)
        {
            double numericValue;
            if (!double.TryParse(numeric.ToString(), out numericValue))
            {
                throw new ArgumentOutOfRangeException("Numeric object required!");
            }

            switch (format)
            {
                case FormattingCode.FLOATING_POINT: Console.WriteLine("{0:f2}", numericValue); break;
                case FormattingCode.PERCENT: Console.WriteLine("{0:p0}", numericValue); break;
                case FormattingCode.REAL_NUMBER: Console.WriteLine("{0,8}", numericValue); break;
                default: throw new ArgumentException("Format not recognized!");
            }
        }

      
    }
}
