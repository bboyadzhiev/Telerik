namespace _01.Binary_passwords
{
    using System;

    internal class BinaryPasswords
    {
        private static void Main(string[] args)
        {
            var pass = Console.ReadLine();

            var starsCount = 0;
            foreach (var ch in pass)
            {
                if (ch == '*')
                {
                    starsCount++;
                }
            }

            ulong result = 1;
            for (int i = 0; i < starsCount; i++)
            {
                result = result + (ulong)Math.Pow(2, i);
            }

            Console.WriteLine(result);
        }
    }
}