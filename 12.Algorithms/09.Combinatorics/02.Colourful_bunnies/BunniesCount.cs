namespace _02.Colourful_bunnies
{
    using System;
    using System.Collections.Generic;

    internal class BunniesCount
    {
        private static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var answersList = new List<int>();
            for (int i = 0; i < count; i++)
            {
                answersList.Add(int.Parse(Console.ReadLine()));
            }
            //var answersList = new List<int>(){ 2, 2, 44, 2, 2, 2, 444, 2, 2 };
            var answersDictionary = new Dictionary<int, int>();

            var total = 0;
            for (int i = 0; i < answersList.Count; i++)
            {
                var answer = answersList[i];
                // it's a single bunny type in the population
                if (answer == 0)
                {
                    // so add it to total
                    total++;
                }
                else
                {
                    // if some bunny answers the same as any other bunny so far
                    if (answersDictionary.ContainsKey(answer))
                    {
                        // increase this answer count
                        answersDictionary[answer]++;
                        // if this answer's count reaches the answer's value
                        if (answersDictionary[answer] == answer)
                        {
                            // add anwser's count to total annd add 1 
                            total = total + answer + 1;
                            // remove this answer from the dictionary (null this answer)
                            answersDictionary.Remove(answer);
                        }
                    }
                    else
                    {
                        // a new unique answer - add it to answers dictionary
                        answersDictionary.Add(answer, 0);
                    }
                }
            }
            
            // adds the remainig answers that were not confirmed by all the bunnies of the same type + 1
            foreach (var answer in answersDictionary)
            {
                total = total + answer.Key + 1;
            }

            Console.WriteLine(total);
        }
    }
}