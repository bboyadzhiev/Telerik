namespace _03.Count_words_in_textfile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class Count_words_in_textfile
    {
        private static void Main(string[] args)
        {
            var sortedWords = WordsCount("..\\..\\inFile.txt", Encoding.GetEncoding("windows-1251"));
            foreach (var word in sortedWords)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }

        public static IOrderedEnumerable<KeyValuePair<string, int>> WordsCount(string textFileName, Encoding encoding)
        {
            StreamReader reader = new StreamReader(textFileName, encoding);
            var wordsDictionary = new Dictionary<string, int>();

            using (reader)
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var words = line.Split(' ', ',', '.');
                    foreach (var word in words)
                    {
                        var lowerCaseWord = word.ToLower();
                        if (wordsDictionary.ContainsKey(lowerCaseWord))
                        {
                            wordsDictionary[lowerCaseWord]++;
                        }
                        else
                        {
                            wordsDictionary.Add(lowerCaseWord, 1);
                        }
                    }
                    line = reader.ReadLine();
                }
            }
            var n = from pair in wordsDictionary
                    orderby pair.Value
                    select pair;
            return n;
        }

        private static SortedDictionary<T, int> TArrayToDictionary<T>(T[] tArray)
        {
            var tCount = new SortedDictionary<T, int>();

            foreach (var item in tArray)
            {
                if (tCount.ContainsKey(item))
                {
                    tCount[item]++;
                }
                else
                {
                    tCount.Add(item, 1);
                }
            }
            return tCount;
        }
    }
}